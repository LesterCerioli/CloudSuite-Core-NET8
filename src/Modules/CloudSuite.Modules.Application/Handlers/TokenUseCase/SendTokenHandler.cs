using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.TokenUseCase.Requests;
using CloudSuite.Modules.Application.Handlers.TokenUseCase.Responses;
using CloudSuite.Modules.Application.Services.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Handlers.TokenUseCase
{
    public class SendTokenHandler : IRequestHandler<SendTokenRequest, SendTokenReponse>
    {
        private readonly ILogger<SendTokenHandler> _logger;
        private readonly IRequestTokenRepository _tokenRepository;
		private readonly IEmailAppService _emailAppService;

        public SendTokenHandler(IRequestTokenRepository tokenRepository, IEmailAppService emailAppService, ILogger<SendTokenHandler> logger)
		{
			_tokenRepository = tokenRepository;
			_emailAppService = emailAppService;
			_logger = logger;

		}

        public async Task<SendTokenReponse> Handle(SendTokenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
