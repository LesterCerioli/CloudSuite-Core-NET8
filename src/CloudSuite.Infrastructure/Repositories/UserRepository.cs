using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByCpf(Cpf cpf)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(Email email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}