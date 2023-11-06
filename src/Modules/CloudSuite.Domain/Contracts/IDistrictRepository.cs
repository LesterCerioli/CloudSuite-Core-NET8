using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
    public interface IDistrictRepository
    {
        Task<District> GetByName(string name);

        Task<IEnumerable<District>> GetList();

        Task Add(District district);

        void Update(District district);

        void Remove(District district);
         
    }
}