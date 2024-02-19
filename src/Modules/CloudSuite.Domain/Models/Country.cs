using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class Country : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        public Country(string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)
        {
            CountryName = countryName;
            Code3 = code3;
            IsBillingEnabled = isBillingEnabled;
            IsShippingEnabled = isShippingEnabled;
            IsCityEnabled = isCityEnabled;
            IsZipCodeEnabled = isZipCodeEnabled;
            IsDistrictEnabled = isDistrictEnabled;
            _states = new List<State>();

        }

        public Country(){ }

        public string? CountryName { get; private set; }

        public string? Code3 { get; private set; }

        public bool? IsBillingEnabled { get; private set; }

        public bool? IsShippingEnabled { get; private set; }

        public bool? IsCityEnabled { get; private set; }

        public bool? IsZipCodeEnabled { get; private set; }

        public bool? IsDistrictEnabled { get; private set; }

        public State State { get; private set; }
        
        public Guid StateId { get; private set; }

        public IReadOnlyCollection<State> States => _states.AsReadOnly();
    }
}