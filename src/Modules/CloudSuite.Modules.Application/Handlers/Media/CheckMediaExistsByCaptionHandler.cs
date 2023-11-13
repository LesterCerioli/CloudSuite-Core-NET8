using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media.Request;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CheckMediaExistsByCaptionHandler : IRequestHandler<CheckMediaExistsByCaptionRequest, CheckMediaExistsByCaptionResponse>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<CheckMediaExistsByCaptionHandler> _logger;

        public CheckMediaExistsByCaptionHandler(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByCaptionHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }
        public async Task<CheckMediaExistsByCaptionResponse> Handle(CheckMediaExistsByCaptionRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckMediaExistsByCaptionRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckMediaExistsByCaptionRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var mediaCaption = await _mediaRepository.GetByCaption(request.Caption);

                    if (mediaCaption != null)
                    {
                        return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckMediaExistsByCaptionResponse(request.Id, false, validationResult));

        }
    }
}
