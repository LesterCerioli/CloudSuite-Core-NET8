using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class MsalIdTokenCache : Entity, IAggregateRoot
    {
        private readonly List<Tenant> _tenants;
        private readonly List<HomeAccount> _homeAccounts;

        public MsalIdTokenCache(string? environment, string? clientId, string? secret)
        {
            Environment = environment;
            ClientId = clientId;
            Secret = secret;
            _tenants = new List<Tenant>();
            _homeAccounts = new List<HomeAccount>();
            
        }

        public string? Environment { get; private set; }

        public string? ClientId { get; private set; }
                

        public string? Secret { get; private set; }

        

        public Tenant Tenant { get; private set; }

        public IReadOnlyCollection<Tenant> Tenants => _tenants.AsReadOnly();

        public HomeAccount HomeAccount { get; private set; }

        public IReadOnlyCollection<HomeAccount> HomeAccounts => _homeAccounts.AsReadOnly();
    }
}
