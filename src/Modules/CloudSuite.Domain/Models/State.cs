using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Diagnostics.Metrics;

namespace CloudSuite.Domain.Models
{
    public class State : Entity, IAggregateRoot
    {
        public string StateName { get; private set; }
        public string UF { get; private set; }
        public Guid CountryId { get; private set; }

        // Propriedade de navegação para Country
        public Country Country { get; private set; }

        // Propriedade de navegação para Cidades
        public IReadOnlyCollection<City> Cities { get; private set; }

        protected State() { }

        public State(Guid id, string stateName, string uf, Guid countryId)
        {
            Id = id;
            StateName = stateName;
            UF = uf;
            CountryId = countryId;
            Cities = new List<City>();
        }

        public State(string? uF, string? stateName)
        {
            UF = uF;
            StateName = stateName;
        }
    }
}