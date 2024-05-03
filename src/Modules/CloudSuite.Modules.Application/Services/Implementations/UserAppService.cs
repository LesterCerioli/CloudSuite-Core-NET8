using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;
using Email = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class UserAppService : IUserAppService
	{
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
		private readonly ILogger<UserAppService> _logger;

        public UserAppService(
            IUserRepository userRepository,
            IMediatorHandler mediator,
            IMapper mapper,
			ILogger<UserAppService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
			_logger = logger;
        }

        public async Task<UserViewModel> GetByCpf(Cpf cpf)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetByCpf(cpf));
		}

		public async Task<UserViewModel> GetByEmail(Email email)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetByEmail(email));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task Save(CreateUserCommand commandCreate)
		{
			var retryPolicy = Policy.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
				onRetry: (exception, timeSpan, retryCount, context) =>
				{
					_logger.LogWarning($"Retry {retryCount} of {context.PolicyWrapKey} at {context.OperationKey}: Due to {exception}");
				});

			await retryPolicy.ExecuteAsync(async () =>
			{
                await _userRepository.Add(commandCreate.GetEntity());
				_logger.LogInformation("User added successfully.");
            });
		}
	}
}