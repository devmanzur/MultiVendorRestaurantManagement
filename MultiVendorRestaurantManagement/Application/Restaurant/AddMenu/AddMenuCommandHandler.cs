using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Restaurants;
using MultiVendorRestaurantManagement.Infrastructure;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.AddMenu
{
    public class AddMenuCommandHandler : IRequestHandler<AddMenuCommand, Result>
    {
        private readonly RestaurantContext _context;

        public AddMenuCommandHandler(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(AddMenuCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.Include(x => x.Menus).SingleOrDefaultAsync(
                x => x.Id == request.RestaurantId,
                cancellationToken: cancellationToken);
            if (restaurant == null) return Result.Failure("invalid restaurant");

            restaurant.AddMenu(new Menu(request.Name, request.NameEng));

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0
                ? Result.Ok("Restaurant registered successfully")
                : Result.Failure<string>("Failed to register restaurant");
        }
    }
}