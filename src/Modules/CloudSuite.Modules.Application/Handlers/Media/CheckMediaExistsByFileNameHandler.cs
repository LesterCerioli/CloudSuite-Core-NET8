using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media.Request;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CheckMediaExistsByFileNameHandler : IRequestHandler<CheckMediaExistsByFileNameRequest, CheckMediaExistsByFileNameResponse>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<CheckMediaExistsByFileNameHandler> _logger;

        public CheckMediaExistsByFileNameHandler(IMediaRepository mediaRepository, ILogger<CheckMediaExistsByFileNameHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }
        public async Task<CheckMediaExistsByFileNameResponse> Handle(CheckMediaExistsByFileNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckMediaExistsByFileNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckMediaExistsByFileNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var mediaFileName = await _mediaRepository.GetByFileName(request.FileName);

                    if (mediaFileName != null)
                    {
                        return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckMediaExistsByFileNameResponse(request.Id, false, validationResult));

        }
    }
}
