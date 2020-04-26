using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    
    public class Menu : Entity{
        public Restaurant Restaurant { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        private ICollection<Food> _items;
        public IReadOnlyList<Food> Items => _items.ToList();


        public Menu(Restaurant restaurant, string name, string nameEng)
        {
            Restaurant = restaurant;
            Name = name;
            NameEng = nameEng;
            _items = new List<Food>();
        }

    }

}