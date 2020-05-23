using CSharpFunctionalExtensions;
using MediatR;

namespace MultiVendorRestaurantManagement.Application.Cuisines
{
    public class RegisterCuisineCommand : IRequest<Result>
    {
        public string NameEng { get; }
        public string Name { get; }
        public string ImageUrl { get; }

        public RegisterCuisineCommand(string nameEng, string name, string imageUrl)
        {
            NameEng = nameEng;
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}