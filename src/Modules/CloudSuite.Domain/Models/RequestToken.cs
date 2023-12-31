using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
	public class RequestToken
	{
		public int Id { get; set; }

		public Guid RequestId { get; set; }

		public string NomeCompleto { get; set; }

		public string Email { get; set; }

		public RequestToken()
		{

		}

		public RequestToken(Guid requestId, string nomeCompleto, string email)
		{
			RequestId = requestId;
			NomeCompleto = nomeCompleto;
			Email = email;
		}

		private string GetToken()
		{
			Random rand = new Random();
			int on = rand.Next(0, 9);
			int tw = rand.Next(0, 9);
			int tr = rand.Next(0, 9);
			int fo = rand.Next(0, 9);

			return on.ToString() + tw.ToString() + tr.ToString() + fo.ToString();
		}
	}
}
