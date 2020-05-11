using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Promotions;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal
{
    public class AddFoodToDealCommandHandler : ICommandHandler<AddFoodToDealCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddFoodToDealCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddFoodToDealCommand request, CancellationToken cancellationToken)
        {
            var deal =
                await _context.Deals.FirstOrDefaultAsync(x => x.Id == request.DealId,
                    cancellationToken: cancellationToken);
            if (deal.HasNoValue()) return Result.Failure("promotion not found");

            var restaurantsIncluded = GenerateDistinctRestaurantWithFoodIds(request.Models);

            if (!restaurantsIncluded.Any()) return Result.Failure("invalid request");

            foreach (var restaurantEntry in restaurantsIncluded)
            {
                var restaurant = await _context.Restaurants.Include(x => x.Foods).FirstOrDefaultAsync(
                    x => x.Id == restaurantEntry.Key,
                    cancellationToken: cancellationToken);
                if (restaurant.HasValue())
                {
                    var foodList = restaurant.Foods
                        .Where(x => restaurantEntry.Value.Contains(x.Id)).ToList();

                    if (foodList.HasValue())
                    {
                        foodList.ForEach(x => { deal.AddItem(x); });
                    }
                }
            }

            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
        }

        private Dictionary<long, List<long>> GenerateDistinctRestaurantWithFoodIds(
            List<FoodPromotionIncludeModel> requestModels)
        {
            var map = new Dictionary<long, List<long>>();
            foreach (var x in requestModels)
            {
                var items = map.ContainsKey(x.RestaurantId) ? map[x.RestaurantId] : new List<long>();
                items.Add(x.FoodId);
                map[x.RestaurantId] = items;
            }

            return map;
        }
    }
}