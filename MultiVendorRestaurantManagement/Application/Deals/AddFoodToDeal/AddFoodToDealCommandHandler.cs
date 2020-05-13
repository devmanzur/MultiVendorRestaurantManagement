using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Promotions;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Deals.AddFoodToDeal
{
    public class AddFoodToDealCommandHandler : ICommandHandler<AddFoodToDealCommand>
    {
        private readonly IAddFoodToDealBackgroundJob _backgroundJob;
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddFoodToDealCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork,
            IAddFoodToDealBackgroundJob backgroundJob)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _backgroundJob = backgroundJob;
        }

        public async Task<Result> Handle(AddFoodToDealCommand request, CancellationToken cancellationToken)
        {
            var deal =
                await _context.Deals.FirstOrDefaultAsync(x => x.Id == request.DealId,
                    cancellationToken);
            if (deal.HasNoValue()) return Result.Failure("promotion not found");

            var restaurantsIncluded = GenerateDistinctRestaurantWithFoodIds(request.Models);

            if (!restaurantsIncluded.Any()) return Result.Failure("invalid request");

            BackgroundJob.Enqueue(() => _backgroundJob.Run(deal.Id, restaurantsIncluded, cancellationToken));
            return Result.Ok("items will be added to promotion, please wait a while");
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