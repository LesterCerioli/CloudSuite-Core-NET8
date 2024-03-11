using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Password_Generator_Context
{
	public class Password : Entity, IAggregateRoot
	{
		public Password(string? senha, int? caracterNumber, DateTimeOffset? createdOn)
		{
			Senha = senha;
			CaracterNumber = caracterNumber;
			CreatedOn = DateTime.Now;
		}

		public Password(int? caracterNumber, string? senha, DateTimeOffset? createdOn)
		{
			CaracterNumber = caracterNumber;
			Senha = senha;
			CreatedOn = createdOn;
		}

		public string? Senha { get; private set; }

		public int? CaracterNumber { get; private set; }

		public DateTimeOffset? CreatedOn { get; private set; }
	}
}
