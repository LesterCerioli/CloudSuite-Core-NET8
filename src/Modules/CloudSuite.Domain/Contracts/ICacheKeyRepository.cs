using CloudSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts
{
    public interface ICacheKeyRepository
    {
        Task<CacheKey> GetCredentialKey(string homeAccountId, string environment, string keyDescriptor, string clientId, string tenantId, string scopes, params string[] additionalKeys);

        Task<CacheKey> GetIosAccountKey(string homeAccountId, string environment);

        Task<CacheKey> GetIosServiceKey(string keyDescriptor, string clientId, string tenantId, string scopes, params string[] extraKeyParts);

        Task<CacheKey> GetIosGenericKey(string keyDescriptor, string clientId, string tenantId);

        Task Add(CacheKey key);

        void Update(CacheKey key);

        void Remove(CacheKey key);
    }
}
