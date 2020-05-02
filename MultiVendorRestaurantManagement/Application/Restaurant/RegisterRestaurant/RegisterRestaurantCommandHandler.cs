using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Invariants;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.ValueObjects;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand, Result>
    {
        private readonly RestaurantContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterRestaurantCommandHandler(RestaurantContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Include(x => x.Localities)
                .SingleOrDefaultAsync(x => x.Id == request.CityId, cancellationToken);
            if (city.HasNoValue()) return Result.Failure<string>("Invalid city");

            var locality = city.Localities.FirstOrDefault(x => x.Id == request.LocalityId);
            if (locality.HasNoValue()) return Result.Failure<string>("Invalid locality");

            var restaurant = new Domain.Restaurants.Restaurant(
                request.Name,
                request.OpeningHour,
                request.ClosingHour,
                request.SubscriptionType,
                request.ContractStatus,
                PhoneNumberValue.Of(SupportedCountryCode.Italy, request.PhoneNumber),
                request.ImageUrl
            );
            restaurant.SetLocality(locality);

            await _context.Restaurants.AddAsync(restaurant, cancellationToken);
            var result = await _unitOfWork.CommitAsync(cancellationToken);

            return result > 0
                ? Result.Ok("Restaurant registered successfully")
                : Result.Failure("Failed to register restaurant");
        }
    }
}