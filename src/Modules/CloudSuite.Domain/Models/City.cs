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

        public City(Guid id, string? cityName, State state)
        {
            StateId = id;
            _states = new List<State>();
            CityName = cityName;
            State = state;
        }

        [Required(ErrorMessage = "Este campo � de preenchimento obrigat�rio.")]
        [MaxLength(50)]

        public string? CityName { get; private set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; private set; }

        public Guid StateId { get; private set; }
    }
}