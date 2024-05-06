using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;
using Polly;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class MediaAppService : IMediaAppService
	{
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
		private readonly ILogger<MediaAppService> _logger;

        public MediaAppService(
            IMediaRepository mediaRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<MediaAppService>  logger)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
            _mediator = mediator;
			_logger = logger;
        }

        public async Task<MediaViewModel> GetByFileName(string fileName)
		{
			return _mapper.Map<MediaViewModel>(await _mediaRepository.GetByFileName(fileName));
		}

		public async Task<MediaViewModel> GetByFileSize(int? fileSize)
		{
			return _mapper.Map<MediaViewModel>(await _mediaRepository.GetByFileSize(fileSize));
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task Save(CreateMediaCommand commandCreate)
		{
			var retryPolicy = Policy.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
				onRetry: (exception, timeSpan, retryCount, context) =>
				{
					_logger.LogWarning($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}: Due to {exception}");
				});

			await retryPolicy.ExecuteAsync(async () => 
			{
                await _mediaRepository.Add(commandCreate.GetEntity());
				_logger.LogInformation("Media added successfully.");
            });
            
		}
	}
}