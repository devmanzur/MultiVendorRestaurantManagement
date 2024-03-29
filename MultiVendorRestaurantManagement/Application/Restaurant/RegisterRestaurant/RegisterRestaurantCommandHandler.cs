﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Domain.ValueObjects;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : ICommandHandler<RegisterRestaurantCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterRestaurantCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Include(x => x.Localities)
                .SingleOrDefaultAsync(x => x.Id == request.CityId, cancellationToken);
            if (city.HasNoValue()) return Result.Failure("invalid city");

            var locality = city.Localities.FirstOrDefault(x => x.Id == request.LocalityId);
            if (locality.HasNoValue()) return Result.Failure("invalid locality");

            var categories = await _context.Categories.AsNoTracking()
                .AsQueryable().Where(x => request.CategoryIds.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            if (categories.HasNoValue() || !categories.Any()) return Result.Failure("invalid category");

            var cuisines = await _context.Cuisines.AsNoTracking()
                .AsQueryable().Where(x => request.CuisineIds.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            if (cuisines.HasNoValue() || !cuisines.Any()) return Result.Failure("invalid cuisine");

            var restaurant = new Domain.Restaurants.Restaurant(
                request.Name,
                request.OpeningHour,
                request.ClosingHour,
                request.SubscriptionType,
                request.ContractStatus,
                PhoneNumberValue.Of(SupportedCountryCode.Italy, request.PhoneNumber),
                request.ImageUrl,
                locality,
                new GeographicLocation(request.Address, request.Lat, request.Lon),
                description: request.Description,
                descriptionEng: request.DescriptionEng
            );
            categories.ForEach(x => restaurant.SupportNewCategory(x));
            cuisines.ForEach(x => restaurant.SupportNewCuisine(x));

            _context.Restaurants.Attach(restaurant);
            var result = await _unitOfWork.CommitAsync(cancellationToken);

            return result > 0
                ? Result.Ok("restaurant registered successfully")
                : Result.Failure("failed to register restaurant");
        }
    }
}