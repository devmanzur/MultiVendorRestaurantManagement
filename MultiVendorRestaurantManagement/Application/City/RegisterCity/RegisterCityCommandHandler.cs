using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using MultiVendorRestaurantManagement.Infrastructure;

namespace MultiVendorRestaurantManagement.Application.City.RegisterCity
{
    public class RegisterCityCommandHandler : IRequestHandler<RegisterCityCommand, Result>
    {
        private readonly RestaurantContext _context;

        public RegisterCityCommandHandler(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(RegisterCityCommand request, CancellationToken cancellationToken)
        {
            var city = new Domain.Cities.City(request.Name, request.NameEng, request.Code);
            
            try
            {
                await _context.Cities.AddAsync(city, cancellationToken);
                var result = await _context.SaveChangesAsync(cancellationToken);

                return result > 0
                    ? Result.Ok("City registered successfully")
                    : Result.Failure("Failed to register city");
            }
            catch (Exception e)
            {
                return Result.Failure<string>(e.Message);
            }
        }
    }
}