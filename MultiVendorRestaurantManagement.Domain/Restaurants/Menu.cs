using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Foods;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Restaurants
{
    public class Menu : Entity
    {
        private readonly IList<Food> _items = new List<Food>();


        protected Menu()
        {
            
        }
        public Menu(string name, string nameEng, string imageUrl)
        {
            CheckRule(new ConditionMustBeTrueRule(!string.IsNullOrEmpty(name), "name must be valid"));
            Name = name;
            NameEng = nameEng;
            ImageUrl = imageUrl;
        }

        public virtual Restaurant Restaurant { get; protected set; }
        public string Name { get; protected set; }
        public string ImageUrl { get; }
        public string NameEng { get; protected set; }
        public IReadOnlyList<Food> Items => _items.ToList();

        public void AddItem(Food food)
        {
            _items.Add(food);
        }
    }
}