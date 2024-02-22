using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class Address : Entity, IAggregateRoot
    {
        private readonly List<District> _districts = new List<District>();

        private readonly List<City> _cities = new List<City>();

        public Address(City city, District district, string contactName, string adressLine1) {
            _districts = new List<District>();
            _cities = new List<City>();
            City = city;
            District = district;
            ContactName = contactName;
            AddressLine1 = adressLine1;
            DistrictId = district.Id;
            CityId = city.Id;
        }

        public Address(string contactName, string adressLine1)
        {
            _districts = new List<District>();
            _cities = new List<City>();
            ContactName = contactName;
            AddressLine1 = adressLine1;
        }

        public Address(){ }

        public string? ContactName { get; private set; }

        public string? AddressLine1 { get; private set; }

        public City City { get; private set; }

        public Guid CityId {get; private set;}
        
        public District District { get; private set; }

        public Guid DistrictId { get; private set; }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        public IReadOnlyCollection<District> Districts => _districts.AsReadOnly();
    }
}