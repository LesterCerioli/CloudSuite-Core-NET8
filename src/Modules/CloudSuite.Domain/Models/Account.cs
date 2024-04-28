using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class Account : Entity, IAggregateRoot
    {
        public Account(string? environment, string? localAccountId, string? homeAccountId, string? tenantId, string? preferredUsername, string? name, string? givenName, string? familyName, IDictionary<string, string> wamAccountIds)
        {
            Environment = environment;
            LocalAccountId = localAccountId;
            HomeAccountId = homeAccountId;
            TenantId = tenantId;
            PreferredUsername = preferredUsername;
            Name = name;
            GivenName = givenName;
            FamilyName = familyName;
            WamAccountIds = wamAccountIds;
        }

        public string? Environment { get; private set; }

        public string? LocalAccountId { get; private set; }

        public string? HomeAccountId { get; private set; }

        public string? TenantId { get; private set; }

        public string? PreferredUsername { get; private set; }

        public string? Name { get; private set; }

        public string? GivenName { get; private set; }

        public string? FamilyName { get; private set; }

        public IDictionary<string, string> WamAccountIds { get; private set; }
    }
}
