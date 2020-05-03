using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.City.RemoveCity
{
    public class RemoveCityCommandHandler  : IRequestHandler<RemoveCityCommand,Result>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCityCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(RemoveCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == request.CityId, cancellationToken);
            if (city.HasValue())
            {
                 _context.Cities.Remove(city);
                 var result = await _unitOfWork.CommitAsync(cancellationToken);
                 return result > 0 ? Result.Ok() : Result.Failure("failed to remove city");
            }
            return Result.Failure("city not found");
        }
    }
}