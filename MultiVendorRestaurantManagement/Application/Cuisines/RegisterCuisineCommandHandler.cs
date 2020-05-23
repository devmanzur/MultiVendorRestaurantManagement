using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Domain.Cuisines;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Cuisines
{
    public class RegisterCuisineCommandHandler : ICommandHandler<RegisterCuisineCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCuisineCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterCuisineCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Cuisines.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == request.Name, cancellationToken);
            if (item.HasValue()) return Result.Failure("cuisine already exists");

            var cuisine = new Cuisine(request.ImageUrl, request.Name, request.NameEng);
            await _context.Cuisines.AddAsync(cuisine, cancellationToken);

            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0 ? Result.Ok() : Result.Failure("failed to register cuisine");
        }
    }
}