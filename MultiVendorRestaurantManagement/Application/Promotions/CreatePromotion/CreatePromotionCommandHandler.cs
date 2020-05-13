using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Promotions;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Promotions.CreatePromotion
{
    public class CreatePromotionCommandHandler : ICommandHandler<CreatePromotionCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePromotionCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            Promotion promotion;
            if (request.IsFixedPriceDiscount)
                promotion = Promotion.CreateFixedPriceDiscountPromotion(request.Name,
                    request.ImageUrl, request.Description, request.DescriptionEng, request.StartDate, request.EndDate,
                    request.FixedPriceModel);
            else
                promotion = Promotion.CreatePercentageDiscountPromotion(request.Name,
                    request.ImageUrl, request.Description, request.DescriptionEng, request.StartDate, request.EndDate,
                    request.PercentageModel);

            await _context.Promotions.AddAsync(promotion, cancellationToken);
            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0
                ? Result.Ok("promotion created")
                : Result.Failure("failed to complete action");
        }
    }
}