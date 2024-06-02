using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class City : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        public City(Guid id, string? cityName)
        {
            
            _states = new List<State>();
            CityName = cityName;
            
        }

        
        public City(string? cityName)
        {
            CityName = cityName;
        }

        
        public string? CityName { get; private set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; set; }

        public Guid StateId { get; set; }
    }
}