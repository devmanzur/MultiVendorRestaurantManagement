using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Base;
using MultiVendorRestaurantManagement.Domain;
using MultiVendorRestaurantManagement.Domain.Cities;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.City.AddLocality
{
    public class AddLocalityCommandHandler : ICommandHandler<AddLocalityCommand>
    {
        private readonly RestaurantManagementContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AddLocalityCommandHandler(RestaurantManagementContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddLocalityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.Include(x => x.Localities).SingleOrDefaultAsync(
                x => x.Id == request.CityId,
                cancellationToken: cancellationToken);
            if (city.HasNoValue()) return Result.Failure("City with given id not found");

            city.AddLocality(new Locality(request.Name, request.Code, request.NameEng));
            var result = await _unitOfWork.CommitAsync(cancellationToken);
            return result > 0
                ? Result.Ok("Locality registered successfully")
                : Result.Failure("Failed to register locality");
        }
    }
}