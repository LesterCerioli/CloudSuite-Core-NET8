using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(Email email);

        Task<User> GetByCpf(Cpf cpf);

        Task<IEnumerable<User>> GetList();

        Task Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}