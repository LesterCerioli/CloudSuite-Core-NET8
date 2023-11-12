using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using CloudSuite.Modules.Application.Validations.User;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateUserCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateUserCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var userEmail = await _userRepository.GetByEmail(command.Email);
                    var UserCpf = await _userRepository.GetByCpf(command.Cpf);

                    if (userEmail != null && UserCpf != null)
                    {
                        return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateUserResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
        }
    }
}
