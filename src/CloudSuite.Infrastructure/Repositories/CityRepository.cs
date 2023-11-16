using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        
        protected readonly CoreDbContext Db;
        protected readonly DbSet<City> DbSet;
        
        public CityRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Cities;

        }
        
        public async Task Add(City city)
        {
            await Task.Run(() => {
                DbSet.Add(city);
                Db.SaveChangesAsync();
            });
        }

        public async Task<City> GetByCityName(string cityName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CityName == cityName);
        }

        public async Task<IEnumerable<City>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(City city)
        {
            DbSet.Remove(city);
        }

        public void Update(City city)
        {
            DbSet.Update(city);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}