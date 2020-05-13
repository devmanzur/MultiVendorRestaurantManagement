using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Promotions.AddItems
{
    public class AddPromotionalItemsCommandHandler : ICommandHandler<AddPromotionalItemsCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddPromotionalItemsCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddPromotionalItemsCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _context.Promotions.FirstOrDefaultAsync(x => x.Id == request.PromotionId,
                cancellationToken);
            if (promotion.HasValue())
            {
                request.FoodIds.ForEach(x => promotion.AddFood(x));
                var result = await _unitOfWork.CommitAsync(cancellationToken);
                return result > 0 ? Result.Ok() : Result.Failure("failed to complete action");
            }

            return Result.Failure("promotion not found");
        }
    }
}