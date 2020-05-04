using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.City.RemoveLocality
{
    public class RemoveLocalityCommandHandler : ICommandHandler<RemoveLocalityCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveLocalityCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveLocalityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.Include(x => x.Localities).FirstOrDefaultAsync(cancellationToken);
            if (city.HasValue())
            {
                var locality = city.Localities.FirstOrDefault(x => x.Id == request.LocalityId);
                if (locality.HasValue())
                {
                    city.RemoveLocality(locality);
                    var result = await _unitOfWork.CommitAsync(cancellationToken);
                    return result > 0
                        ? Result.Ok("Locality removed successfully")
                        : Result.Failure("Failed to remove locality");
                }
            }
            return Result.Failure("Failed to remove locality");
        }
    }
}