using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Handlers.User.Request;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using CloudSuite.Modules.Application.Validations.User;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.User
{
    public class CheckUserExistsByEmailHandler : IRequestHandler<CheckUserExistsByEmailRequest, CheckUserExistsByEmailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CheckMediaExistsByCaptionHandler> _logger;

        public CheckUserExistsByEmailHandler(IUserRepository userRepository, ILogger<CheckMediaExistsByCaptionHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<CheckUserExistsByEmailResponse> Handle(CheckUserExistsByEmailRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckUserExistsByEmailRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckUserExistsByEmailRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var mediaCaption = await _userRepository.GetByEmail(request.Email);

                    if (mediaCaption != null)
                    {
                        return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, false, validationResult));

        }
    }
}
