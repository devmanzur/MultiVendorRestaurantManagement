using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MultiVendorRestaurantManagement.Domain.Base;
using MultiVendorRestaurantManagement.Domain.Rules;
using static System.String;

namespace MultiVendorRestaurantManagement.Domain.Cities
{
    public class City : AggregateRoot
    {
        public City(string name, string nameEng, string code)
        {
            Name = name;
            NameEng = nameEng;
            Code = code;
        }

        public void Create()
        {
            AddDomainEvent(new CityRegisteredEvent(Name));
        }

        public string Name { get; protected set; }
        public string NameEng { get; protected set; }
        public string Code { get; protected set; }

        private List<Locality> _localities = new List<Locality>();
        public virtual IReadOnlyList<Locality> Localities => _localities.ToList();

        public void AddLocality(Locality locality)
        {
            CheckRule(new ConditionMustBeTrue(
                _localities.FirstOrDefault(x =>
                    string.Equals(x.Name, locality.Name, StringComparison.InvariantCultureIgnoreCase)) == null,
                "city must not contain locality with same name"));
            _localities.Add(locality);
            AddDomainEvent(new LocalityAddedEvent(Id, locality.Name));
        }

        public void RemoveLocality(Locality locality)
        {
            CheckRule(new ConditionMustBeTrue(
                _localities.FirstOrDefault(x => x.Id == locality.Id) != null,
                "locality not found"));
            _localities.Remove(locality);
            AddDomainEvent(new LocalityRemovedEvent(Id,locality.Id));
        }
    }
}