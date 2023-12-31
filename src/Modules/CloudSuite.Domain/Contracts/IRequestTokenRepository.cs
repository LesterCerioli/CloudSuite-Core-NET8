using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Domain.Models;

namespace CloudSuite.Domain.Contracts
{
	public interface IRequestTokenRepository
	{
		Task RemoveByEmail(string emailAddress);
		Task Add(RequestToken requestToken);
		Task<RequestToken> GetByRequestId(Guid requestId);
		Task Update(RequestToken requestToken);
	}
}
