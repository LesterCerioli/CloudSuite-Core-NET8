using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Email;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class EmailAppService : IEmailAppService
	{
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
		private readonly ILogger<EmailAppService> _logger;

        public EmailAppService(
            IEmailRepository emailRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<EmailAppService> logger)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
            _mediator = mediator;
			_logger = logger;
        }

        public async Task<EmailViewModel> GetByCodeErrorEmail(CodeErrorEmail codeErrorEmail)
		{
			return _mapper.Map<EmailViewModel>(await _emailRepository.GetByCodeErrorEmail(codeErrorEmail));
		}

		public async Task<EmailViewModel> GetByRecipient(string recipient)
		{
			return _mapper.Map<EmailViewModel>(await _emailRepository.GetByRecipient(recipient));
		}

		public async Task<EmailViewModel> GetBySender(string sender)
		{
			return _mapper.Map<EmailViewModel>(await _emailRepository.GetBySender(sender));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task Save(CreateEmailCommand commandCreate)
		{

			await _emailRepository.Add(commandCreate.GetEntity());
		}
	}
}
