using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly CoreDbContext Db;
        protected readonly DbSet<User> DbSet;
        
        public UserRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.Users;

        }
        
        public async Task Add(User user)
        {
            await Task.Run(() => { 
                DbSet.Add(user);
                Db.SaveChanges();
            });
        }

        public async Task<User> GetByCpf(Cpf cpf)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Cpf == cpf);
        }

        public async Task<User> GetByEmail(Email email)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(User user)
        {
            DbSet.Remove(user);
        }

        public void Update(User user)
        {
            DbSet.Update(user);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}