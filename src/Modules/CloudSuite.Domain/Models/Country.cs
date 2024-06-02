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
        public string CountryName { get; private set; }
        public string Code3 { get; private set; }
        public bool IsBillingEnabled { get; private set; }
        public bool IsShippingEnabled { get; private set; }
        public bool IsCityEnabled { get; private set; }
        public bool IsZipCodeEnabled { get; private set; }
        public bool IsDistrictEnabled { get; private set; }

        // Propriedade de navegação para States
        public IReadOnlyCollection<State> States { get; private set; }

        
        public Country(Guid id, string countryName, string code3, bool isBillingEnabled, bool isShippingEnabled, bool isCityEnabled, bool isZipCodeEnabled, bool isDistrictEnabled)
        {
            Id = id;
            CountryName = countryName;
            Code3 = code3;
            IsBillingEnabled = isBillingEnabled;
            IsShippingEnabled = isShippingEnabled;
            IsCityEnabled = isCityEnabled;
            IsZipCodeEnabled = isZipCodeEnabled;
            IsDistrictEnabled = isDistrictEnabled;
            States = new List<State>();
        }

        public Country(string countryName, string code3)
        {
            CountryName = countryName;
            Code3 = code3;
        }
    }
}