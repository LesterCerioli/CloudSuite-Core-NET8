using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task Add(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByCnpj(Cnpj cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByFantasyName(string fantasyName)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByRegisterName(string registerName)
        {
            throw new NotImplementedException();
        }

        public void Remove(Company company)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}