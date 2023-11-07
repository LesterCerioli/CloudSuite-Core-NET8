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

        public City(Guid id) {
            StateId = id;
            _states = new List<State>();
        }

        public City()
        {

        }

        [Required(ErrorMessage = "Este campo � de preenchimento obrigat�rio.")]
        [MaxLength(100)]

        public string? CityName { get; private set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public State State { get; private set; }

        public Guid StateId { get; private set; }
    }
}