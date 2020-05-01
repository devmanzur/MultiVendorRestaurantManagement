using MultiVendorRestaurantManagement.Domain.Base;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class Locality: Entity
    {
        public Locality(string name, int code, string nameEng)
        {
            Name = name;
            Code = code;
            NameEng = nameEng;
        }

        public virtual City City { get; protected set; }
        public int Code { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
    }
}