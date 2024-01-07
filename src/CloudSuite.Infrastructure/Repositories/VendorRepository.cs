using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        protected readonly CoreDbContext Db;
        protected readonly DbSet<Vendor> DbSet;
        
        public VendorRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Vendors;

        }
        
        public async Task Add(Vendor vendor)
        {
            await Task.Run(() => { 
                DbSet.Add(vendor);
                Db.SaveChanges();
            });
        }

        public async Task<Vendor> GetByCnpj(Cnpj cnpj)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cnpj == cnpj);
        }

        

        public async Task<Vendor> GetByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<Vendor> GetByCreatedOn(DateTimeOffset? createdOn)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.CreatedOn == createdOn);
        }
        
        public async Task<IEnumerable<Vendor>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Vendor vendor)
        {
            DbSet.Remove(vendor);
        }

        public void Update(Vendor vendor)
        {
            DbSet.Update(vendor);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        
    }
}