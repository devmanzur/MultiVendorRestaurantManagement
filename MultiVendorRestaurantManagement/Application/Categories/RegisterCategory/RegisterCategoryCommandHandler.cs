using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.Common;
using MultiVendorRestaurantManagement.Infrastructure.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Categories.RegisterCategory
{
    public class RegisterCategoryCommandHandler : IRequestHandler<RegisterCategoryCommand, Result>
    {
        private readonly IContext _context;

        public RegisterCategoryCommandHandler(IContext context)
        {
            _context = context;
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

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? Result.Ok() : Result.Failure("failed to register category");
        }
    }
}