using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Invariants;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.ValueObjects;
using MultiVendorRestaurantManagement.Infrastructure;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand, Result<string>>
    {
        private readonly RestaurantContext _context;

        public RegisterRestaurantCommandHandler(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Include(x => x.Localities)
                .SingleOrDefaultAsync(x => x.Id == request.CityId, cancellationToken);
            if (city == null) return Result.Failure<string>("Invalid city");

            var locality = city.Localities.FirstOrDefault(x => x.Id == request.LocalityId);
            if (locality == null) return Result.Failure<string>("Invalid locality");

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
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0
                ? Result.Ok("Restaurant registered successfully")
                : Result.Failure<string>("Failed to register restaurant");
        }
    }
}