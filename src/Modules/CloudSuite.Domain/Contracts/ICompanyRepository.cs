using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Domain.Contracts
{
    public interface ICompanyRepository
    {
        Task<Company> GetByCnpj(Cnpj cnpj);

        Task<Company> GetByFantasyName(string fantasyName);

        Task<Company> GetByRegisterName(string registerName);

        Task<IEnumerable<Company>> GetAll();

        Task Add(Company company);

        void Update(Company company);

        void Remove(Company company);
         
    }
}