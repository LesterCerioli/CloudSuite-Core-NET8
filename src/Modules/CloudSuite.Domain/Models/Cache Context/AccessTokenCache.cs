using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cache_Context
{
    public class AccessTokenCache : Entity, IAggregateRoot
    {
        public AccessTokenCache(string? key, string? token, DateTime? expiry)
        {
            Key = key;
            Token = token;
            Expiry = expiry;
        }

        public string? Key { get; private set; }

        public string? Token { get; private set; }

        public DateTime? Expiry { get; private set; }
    }
}
