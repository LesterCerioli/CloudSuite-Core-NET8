using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media.Request;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CheckMediaExistsByFileSizeHandler : IRequestHandler<CheckMediaExistsByFileSizeRequest, CheckMediaExistsByFileSizeResponse>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<CheckMediaExistsByFileSizeHandler> _logger;

        public CheckMediaExistsByFileSizeHandler(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByFileSizeHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }
        public async Task<CheckMediaExistsByFileSizeResponse> Handle(CheckMediaExistsByFileSizeRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckMediaExistsByFileSizeRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckMediaExistsByFileSizeRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var emailRecipient = await _mediaRepository.GetByFileSize(request.FileSize);

                    if (emailRecipient != null)
                    {
                        return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckMediaExistsByFileSizeResponse(request.Id, false, validationResult));

        }
    }
}
