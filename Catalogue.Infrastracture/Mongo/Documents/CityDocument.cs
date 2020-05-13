using System.Collections.Generic;

namespace Catalogue.Infrastracture.Mongo.Documents
{
    public class CityDocument : BaseDocument
    {
        public CityDocument(long cityId, string code, string name, string nameEng)
        {
            CityId = cityId;
            Code = code;
            Name = name;
            NameEng = nameEng;
            Localities = new List<LocalityRecord>();
        }

        public long CityId { get; protected set; }
        public string Code { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public List<LocalityRecord> Localities { get; protected set; }
    }


    public class LocalityRecord
    {
        public LocalityRecord(long localityId, int code, string name, string nameEng)
        {
            LocalityId = localityId;
            Code = code;
            Name = name;
            NameEng = nameEng;
        }

        public long LocalityId { get; protected set; }
        public int Code { get; protected set; }
        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
    }
}