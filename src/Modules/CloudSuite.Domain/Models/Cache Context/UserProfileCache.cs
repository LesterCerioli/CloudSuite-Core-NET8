using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Cache_Context
{
    public class UserProfileCache : Entity, IAggregateRoot
    {
        public UserProfileCache(string? key, string? username, Email email)
        {
            Key = key;
            Username = username;
            Email = email;
        }

        public string? Key { get; private set; }

        public string? Username { get; private set; }

        public Email Email { get; private set; }
    }
}
