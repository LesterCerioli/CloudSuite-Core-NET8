using CloudSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts
{
    public interface IAccountRepository
    {
        Task<Account> GetByEnvironment(string environmentId);

        Task<Account> GetByPreferredUsername(string preferredUsername);

        Task<Account> GetByName(string name);

        Task<IEnumerable<Account>> GetKist();

        Task Add(Account account);

        void Update(Account account);

        void Remove(Account account);
    }
}
