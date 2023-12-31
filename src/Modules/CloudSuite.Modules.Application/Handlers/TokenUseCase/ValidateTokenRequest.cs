﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.TokenUseCase
{
	public class ValidateTokenRequest : IRequest< ValidateTokenResponse>
	{
	}
}
