using System.Data.Common;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        protected readonly DbSet<State> DbSet;
        protected readonly CoreDbContext Db;
        
        public StateRepository(CoreDbContext context)
        {
            Db = context;
            DbSet = context.States;

        }
        public async Task Add(State state)
        {
            await Task.Run(() => { 
                DbSet.Add(state);
                Db.SaveChanges();
            });
            
            
        }

        public async Task<State> GetByName(string stateName)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.StateName == stateName);
        }

        public async Task<State> GetByUF(string uf)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.UF == uf);
        }

        public async Task<IEnumerable<State>> GetList()
        {
            return await DbSet.ToListAsync();
        }

        public void Remove(State state)
        {
            DbSet.Remove(state);
        }

        public void Update(State state)
        {
            DbSet.Update(state);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}