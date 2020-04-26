using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain
{
    public class City : AggregateRoot
    {
        public City(string name, string nameEng, string code, ICollection<Area> areas)
        {
            Name = name;
            NameEng = nameEng;
            Code = code;
            _areas = areas;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Code { get; protected set; }

        private ICollection<Area> _areas;
        public IReadOnlyList<Area> Areas => _areas.ToList();
    }
}