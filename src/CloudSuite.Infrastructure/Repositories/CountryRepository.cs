using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        
        protected readonly DbSet<Country> DbSet;
        protected readonly CoreDbContext Db; 
        
        public CountryRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Countries;

        }

        

        public async Task Add(Country country)
        {
            await Task.Run(() => {
                DbSet.Add(country);
                Db.SaveChanges();


            });
            
        }

        public async Task<Country> GetByCode(string code3)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Code3 == code3);
        }

        public async Task<Country> GetByName(string countryName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CountryName == countryName);
        }

        public async Task<IEnumerable<Country>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Country country)
        {
            DbSet.Remove(country);
        }

        public void Update(Country country)
        {
            DbSet.Update(country);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}