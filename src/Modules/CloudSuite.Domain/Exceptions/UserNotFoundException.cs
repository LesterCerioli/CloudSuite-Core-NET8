﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Exceptions
{
	public sealed class UserNotFoundException : NotFoundException
	{
		public UserNotFoundException(int userId)
			: base($"The user with the identifier {userId} was not found.")
		{
		}
	}
}
