using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.City
{
    public class City : AggregateRoot
    {
        public City(string name, string nameEng, string code)
        {
            Name = name;
            NameEng = nameEng;
            Code = code;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Code { get; protected set; }

        private List<Locality> _localities = new List<Locality>();
        public virtual IReadOnlyList<Locality> Localities => _localities.ToList();

        public void AddLocality(Locality area)
        {
            _localities.Add(area);
        }
    }
}