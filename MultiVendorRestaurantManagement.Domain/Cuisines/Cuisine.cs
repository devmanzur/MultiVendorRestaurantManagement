using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Restaurants;

namespace MultiVendorRestaurantManagement.Domain.Cuisines
{
    public class Cuisine : AggregateRoot
    {
        public string ImageUrl { get; protected set; }
        public string Name { get; private set; }
        public string NameEng { get; private set; }

        private readonly List<Food> _foods = new List<Food>();
        public IReadOnlyList<Food> Foods => _foods.ToList();

        private readonly List<RestaurantCuisine> _restaurants = new List<RestaurantCuisine>();
        public IReadOnlyList<RestaurantCuisine> Restaurants => _restaurants.ToList();

        public Cuisine(string imageUrl, string name, string nameEng)
        {
            ImageUrl = imageUrl;
            Name = name;
            NameEng = nameEng;
        }
        
        public override IDomainEvent GetAddedDomainEvent()
        {
            return new CuisineCreatedEvent();
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
           return new CuisineDeletedEvent();
        }
    }
}