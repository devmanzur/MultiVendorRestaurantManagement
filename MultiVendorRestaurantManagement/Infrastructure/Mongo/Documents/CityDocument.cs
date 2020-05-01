using System.Collections.Generic;

namespace MultiVendorRestaurantManagement.Infrastructure.Mongo.Documents
{
    public class CityDocument : BaseDocument
    {
        public long CityId { get; private set; }
        public int Code { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public List<LocalityRecord> Localities { get; set; }
    }
    
    
    public class LocalityRecord 
    {
        public long LocalityId { get; private set; }
        public int Code { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
    }
}