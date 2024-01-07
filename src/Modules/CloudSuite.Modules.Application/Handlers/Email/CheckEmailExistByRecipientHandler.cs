using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Email.Request;
using CloudSuite.Modules.Application.Handlers.Email.Responses;
using CloudSuite.Modules.Application.Validations.Email;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Email
{
    public class CheckEmailExistByRecipientHandler : IRequestHandler<CheckEmailExistByRecipientRequest, CheckEmailExistByRecipientResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<CheckEmailExistByRecipientHandler> _logger;

        public CheckEmailExistByRecipientHandler(IEmailRepository emailRepository, ILogger<CheckEmailExistByRecipientHandler> logger)
        {
            _emailRepository = emailRepository;
            _logger = logger;
        }
        public async Task<CheckEmailExistByRecipientResponse> Handle(CheckEmailExistByRecipientRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckEmailExistByRecipientRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckEmailExistByRecipientRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var emailRecipient = await _emailRepository.GetByRecipient(request.Recipient);

                    if (emailRecipient != null)
                    {
                        return await Task.FromResult(new CheckEmailExistByRecipientResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckEmailExistByRecipientResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckEmailExistByRecipientResponse(request.Id, false, validationResult));

        }
    }
}
