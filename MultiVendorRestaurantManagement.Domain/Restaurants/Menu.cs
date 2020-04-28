using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Menu : Entity
    {
        public virtual Restaurant Restaurant { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        private IList<Food> _items = new List<Food>();
        public IReadOnlyList<Food> Items => _items.ToList();


        public Menu(string name, string nameEng)
        {
            Name = name;
            NameEng = nameEng;
        }
    }
}