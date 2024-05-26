using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts
{
    public interface ICredentialRepository
    {
        Task<CredentialCache> GetByCredentialType(string credentialType);

        Task<CredentialCache> GetBySecret(string secret);

        Task<IEnumerable<CredentialCache>> GetList();

        Task Add(CredentialCache credentialCache);

        void Update();

        void Remove(CredentialCache credentialCache);
    }
}
