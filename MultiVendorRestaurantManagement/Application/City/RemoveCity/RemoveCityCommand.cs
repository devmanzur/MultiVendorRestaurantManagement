using CSharpFunctionalExtensions;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.City.RemoveCity
{
    public class RemoveCityCommand : IRequest<Result>
    {
        public long CityId { get; }

        public RemoveCityCommand(long cityId)
        {
            CityId = cityId;
        }
    }
}