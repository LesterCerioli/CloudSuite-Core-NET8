using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        protected readonly CoreDbContext Db;
        protected readonly DbSet<Company> DbSet;
        
        public CompanyRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Companies;

        }
        
        public async Task Add(Company company)
        {
            await Task.Run(() => {
                DbSet.Add(company);
                Db.SaveChangesAsync();
            });

            
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Company> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
        }

        public async Task<Company> GetByFantasyName(string fantasyName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.FantasyName == fantasyName);
        }

        public async Task<Company> GetByRegisterName(string registerName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.RegisterName == registerName);
        }

        public void Remove(Company company)
        {
            DbSet.Remove(company);
        }

        public void Update(Company company)
        {
            DbSet.Update(company);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}