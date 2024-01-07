using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        protected readonly CoreDbContext Db; 
        protected readonly DbSet<District> DbSet;
        
        public DistrictRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Districts;

        }

        

        public async Task Add(District district)
        {
            await Task.Run(() => { 
                DbSet.Add(district);
                Db.SaveChanges();
            });
        }

        public async Task<District> GetByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<IEnumerable<District>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(District district)
        {
            DbSet.Remove(district);
        }

        public void Update(District district)
        {
            DbSet.Update(district);
        }

        public void Dispose()
        {
            Db.Dispose();

        }
    }
}