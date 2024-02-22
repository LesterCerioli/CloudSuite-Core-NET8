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
        private readonly List<Country> _countries;

        public State(string uf, string stateName, Country country, Guid countryId)
        {
            _countries = new List<Country>();
            UF = uf;
            StateName = stateName;
            Country = country;
            CountryId = countryId;
        }

        public State(string uf, string stateName)
        {
            _countries = new List<Country>();
            UF = uf;
            StateName = stateName;
        }

        public State(){ }

        public string? StateName { get; private set; }

        public string? UF { get; private set; }

        public Country Country { get; private set; }

        public Guid CountryId { get; private set; }

        public IReadOnlyCollection<Country> Countries => _countries.AsReadOnly();
    }
}