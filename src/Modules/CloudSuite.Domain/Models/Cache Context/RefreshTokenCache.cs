using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cache_Context
{
    public class RefreshTokenCache : Entity, IAggregateRoot
    {
        public RefreshTokenCache(string? key, string? token)
        {
            Key = key;
            Token = token;
        }

        public string? Key { get; private set; }
        
        public string? Token { get; private set; }
    }
}
