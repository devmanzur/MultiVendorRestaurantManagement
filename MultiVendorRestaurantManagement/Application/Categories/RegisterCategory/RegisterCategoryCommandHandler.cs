using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Categories;
using MultiVendorRestaurantManagement.Domain.Category;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Categories.RegisterCategory
{
    public class RegisterCategoryCommandHandler : ICommandHandler<RegisterCategoryCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCategoryCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == request.Name
                                          && x.Categorize == request.Categorize,
                    cancellationToken);
            if (item.HasValue()) return Result.Failure("category already exists");

            var category = new Category(request.Name, request.NameEng, request.ImageUrl, request.Categorize);
            await _context.Categories.AddAsync(category, cancellationToken);

            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0 ? Result.Ok() : Result.Failure("failed to register category");
        }
    }
}