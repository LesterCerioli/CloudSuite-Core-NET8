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

        public async Task<Address> GetByAddressLine(string AddressLine1)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.AddressLine == accountDigit);
        }

        public async Task<Address> GetByContactName(string contactName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Address address)
        {
            throw new NotImplementedException();
        }

        public void Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}