using CloudSuite.Domain.Models.Client_Context;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class CredentialCache : Entity, IAggregateRoot
    {
        // If each CredentialCache can have multiple Clients, this should be a list of Client, not CredentialCache.
        private readonly List<Client> _clients;

        public CredentialCache(string? credentialType, string? secret)
        {
            CredentialType = credentialType;
            Secret = secret;
            _clients = new List<Client>();
        }



        public string? CredentialType { get; private set; }

        public string? Secret { get; private set; }

        // Assuming Client is another entity related to this CredentialCache
        // If this property was supposed to represent a single client, ensure to initialize it properly somewhere in your business logic.
        public IReadOnlyCollection<Client> Clients => _clients.AsReadOnly();
    }
}
