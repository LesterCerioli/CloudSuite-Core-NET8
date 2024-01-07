using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        
        protected readonly CoreDbContext Db;
        protected readonly DbSet<Address> DbSet;

        public AddressRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Addresses;
        }

        public async Task Add(Address address)
        {
            await Task.Run(() => { 
                DbSet.Add(address);
                Db.SaveChanges();
            });
        }

        public async Task<Address> GetByAddressLine(string addressLine1)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.AddressLine1 == addressLine1);
        }

        public async Task<Address> GetByContactName(string contactName)
        {
            return await DbSet.SingleOrDefaultAsync(a => a.ContactName == contactName);
        }

        public async Task<IEnumerable<Address>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(Address address)
        {
            DbSet.Remove(address);
        }

        public void Update(Address address)
        {
            DbSet.Update(address);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}