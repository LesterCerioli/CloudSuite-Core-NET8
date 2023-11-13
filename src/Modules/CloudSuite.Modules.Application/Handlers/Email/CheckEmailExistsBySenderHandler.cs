using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Email.Request;
using CloudSuite.Modules.Application.Handlers.Email.Responses;
using CloudSuite.Modules.Application.Validations.Email;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Email
{
    public class CheckEmailExistsBySenderHandler : IRequestHandler<CheckEmailExistBySenderRequest, CheckEmailExistBySenderResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<CheckEmailExistsBySenderHandler> _logger;

        public CheckEmailExistsBySenderHandler(IEmailRepository emailRepository, ILogger<CheckEmailExistsBySenderHandler> logger)
        {
            _emailRepository = emailRepository;
            _logger = logger;
        }
        public async Task<CheckEmailExistBySenderResponse> Handle(CheckEmailExistBySenderRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckEmailExistBySenderRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckEmailExistBySenderRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var emailSender = await _emailRepository.GetBySender(request.Sender);

                    if (emailSender != null)
                    {
                        return await Task.FromResult(new CheckEmailExistBySenderResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckEmailExistBySenderResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckEmailExistBySenderResponse(request.Id, false, validationResult));

        }
    }
}
