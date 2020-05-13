using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal
{
    public class AddFoodToDealBackgroundJob : IAddFoodToDealBackgroundJob
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddFoodToDealBackgroundJob(IUnitOfWork unitOfWork, RestaurantManagementContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task Run(long dealId, Dictionary<long, List<long>> restaurantsIncluded,
            CancellationToken cancellationToken)
        {
            var deal =
                await _context.Deals.FirstOrDefaultAsync(x => x.Id == dealId,
                    cancellationToken);
            if (deal.HasNoValue()) return;

            foreach (var restaurantEntry in restaurantsIncluded)
            {
                var restaurant = await _context.Restaurants.Include(x => x.Foods).FirstOrDefaultAsync(
                    x => x.Id == restaurantEntry.Key,
                    cancellationToken);
                if (restaurant.HasValue())
                {
                    var foodList = restaurant.Foods
                        .Where(x => restaurantEntry.Value.Contains(x.Id)).ToList();

                    if (foodList.HasValue()) foodList.ForEach(x => { AddToDeal(deal, x); });
                }
            }

            await _unitOfWork.CommitAsync(cancellationToken);
        }

        private static void AddToDeal(Deal deal, Domain.Foods.Food x)
        {
            try
            {
                deal.AddItem(x);
            }
            catch (BusinessRuleValidationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public interface IAddFoodToDealBackgroundJob
    {
        Task Run(long dealId, Dictionary<long, List<long>> restaurantsIncluded,
            CancellationToken cancellationToken);
    }
}