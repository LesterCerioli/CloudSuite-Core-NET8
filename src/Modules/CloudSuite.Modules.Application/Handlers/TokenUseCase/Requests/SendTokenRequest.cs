using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Handlers.TokenUseCase.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.TokenUseCase.Requests
{
	public class SendTokenRequest :IRequest<SendTokenReponse>
	{
	}
}
