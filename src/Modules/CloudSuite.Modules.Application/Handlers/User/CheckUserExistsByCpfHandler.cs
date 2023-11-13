using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.User.Request;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using CloudSuite.Modules.Application.Validations.User;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.User
{
    public class CheckUserExistsByCpfHandler : IRequestHandler<CheckUserExistsByCpfRequest, CheckUserExistsByCpfResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CheckUserExistsByCpfHandler> _logger;

        public CheckUserExistsByCpfHandler(IUserRepository userRepository, ILogger<CheckUserExistsByCpfHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<CheckUserExistsByCpfResponse> Handle(CheckUserExistsByCpfRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckUserExistsByCpfRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckUserExistsByCpfRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var UserCpf = await _userRepository.GetByCpf(request.Cpf);

                    if (UserCpf != null)
                    {
                        return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, false, validationResult));

        }
    }
}
