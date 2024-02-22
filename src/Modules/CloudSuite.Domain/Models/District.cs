using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class District : Entity, IAggregateRoot
    {

        private readonly List<City> _cities;
        public District(City city, Guid cityId, string name, string type, string location)
        {
            _cities = new List<City>(0);
            Name = name;
            Type = type;
            Location = location;
            City = city;
            CityId = cityId;
        }

        public District(string name, string type, string location)
        {
            _cities = new List<City>(0);
            Name = name;
            Type = type;
            Location = location;
        }

        public District() { }

        public City City { get; private set; }

        public Guid CityId { get; private set; }

        public string? Name { get; private set; }

        public string? Type {  get; private set; }

        public string? Location { get; private set; }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();
    }
}