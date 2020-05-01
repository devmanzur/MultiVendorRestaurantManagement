using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Utils;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MultiVendorRestaurantManagement.Domain.City;
using MultiVendorRestaurantManagement.Infrastructure;
using MultiVendorRestaurantManagement.Infrastructure.EntityFramework;

namespace MultiVendorRestaurantManagement.Application.City.RegisterLocality
{
    public class RegisterLocalityCommandHandler : IRequestHandler<RegisterLocalityCommand, Result>
    {
        private readonly RestaurantContext _context;

        public RegisterLocalityCommandHandler(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(RegisterLocalityCommand request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.Include(x => x.Localities).SingleOrDefaultAsync(
                x => x.Id == request.CityId,
                cancellationToken: cancellationToken);
            if (city.HasNoValue()) return Result.Failure("City with given id not found");

            city.AddLocality(new Locality(request.Name, request.Code, request.NameEng));
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0
                ? Result.Ok("Locality registered successfully")
                : Result.Failure("Failed to register locality");
        }
    }
}