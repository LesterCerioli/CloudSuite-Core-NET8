using CloudSuite.Domain.Models.Password_Generator_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts.Password_Generator_Context
{
	public interface IPasswordRepository
	{
		Task<Password> GetByCaracter(int caracterNumber);

		Task<Password> GetBySecret(string senha);

		Task<IEnumerable<Password>> GetList();
		
		Task Add(Password password);

		void Update(Password password);

		void Remove(Password password);
	}
}
