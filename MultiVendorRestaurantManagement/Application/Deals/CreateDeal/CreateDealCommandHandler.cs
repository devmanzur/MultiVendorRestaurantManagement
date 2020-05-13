using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Deals;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Deals.CreateDeal
{
    public class CreateDealCommandHandler : ICommandHandler<CreateDealCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDealCommandHandler(IUnitOfWork unitOfWork, RestaurantManagementContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Result> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            Deal deal;
            if (request.IsPackageDeal)
                deal = Deal.CreateBuyXGetYDeal(request.Name,
                    request.Description, request.DescriptionEng, request.ImageUrl, request.StartDate, request.EndDate,
                    request.PackageDiscountModel);
            else if (request.IsFixedPriceDiscount)
                deal = Deal.CreateFixedDiscountDeal(request.Name,
                    request.Description, request.DescriptionEng, request.ImageUrl, request.StartDate, request.EndDate,
                    request.FixedPriceModel);
            else
                deal = Deal.CreatePercentageDiscountDeal(request.Name,
                    request.Description, request.DescriptionEng, request.ImageUrl, request.StartDate, request.EndDate,
                    request.PercentageModel);

            await _context.Deals.AddAsync(deal, cancellationToken);
            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0
                ? Result.Ok("promotion created")
                : Result.Failure("failed to complete action");
        }
    }
}