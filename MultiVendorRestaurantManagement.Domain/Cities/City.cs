using System;
using System.Collections.Generic;
using System.Linq;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Rules;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class City : AggregateRoot
    {
        private readonly List<Locality> _localities = new List<Locality>();

        public City(string name, string nameEng, string code)
        {
            Name = name;
            NameEng = nameEng;
            Code = code;
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Code { get; protected set; }
        public virtual IReadOnlyList<Locality> Localities => _localities.ToList();

        public void AddLocality(Locality locality)
        {
            CheckRule(new ConditionMustBeTrueRule(
                _localities.FirstOrDefault(x =>
                    string.Equals(x.Name, locality.Name, StringComparison.InvariantCultureIgnoreCase)) == null,
                "city must not contain locality with same name"));
            _localities.Add(locality);
            AddDomainEvent(new LocalityAddedEvent(Id, locality.Name));
        }

        public void RemoveLocality(Locality locality)
        {
            CheckRule(new ConditionMustBeTrueRule(
                _localities.FirstOrDefault(x => x.Id == locality.Id) != null,
                "locality not found"));
            _localities.Remove(locality);
            AddDomainEvent(new LocalityRemovedEvent(Id, locality.Id));
        }

        public override IDomainEvent GetAddedDomainEvent()
        {
            return new CityRegisteredEvent(Name);
        }

        public override IDomainEvent GetRemovedDomainEvent()
        {
            return new CityRemovedEvent(Id);
        }
    }
}