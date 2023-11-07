using CloudSuite.Domain.Models;

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