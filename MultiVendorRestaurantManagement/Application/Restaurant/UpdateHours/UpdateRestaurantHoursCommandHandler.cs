using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.Restaurant.UpdateHours
{
    public class UpdateRestaurantHoursCommandHandler : ICommandHandler<UpdateRestaurantHoursCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRestaurantHoursCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateRestaurantHoursCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(x => x.Id == request.RestaurantId,
                cancellationToken: cancellationToken);
            if (restaurant.HasValue())
            {
                restaurant.UpdateHours(request.OpeningHour, request.ClosingHour);
                var result = await _unitOfWork.CommitAsync(cancellationToken);
                return result > 0 ? Result.Ok() : Result.Failure("failed to update");
            }

            return Result.Failure("restaurant not found");
        }
    }
}