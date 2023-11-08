using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;

namespace CloudSuite.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        public Task Add(State state)
        {
            throw new NotImplementedException();
        }

        public Task<State> GetByName(string stateName)
        {
            throw new NotImplementedException();
        }

        public Task<State> GetByUF(string uf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<State>> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(State state)
        {
            throw new NotImplementedException();
        }

        public void Update(State state)
        {
            throw new NotImplementedException();
        }
    }
}