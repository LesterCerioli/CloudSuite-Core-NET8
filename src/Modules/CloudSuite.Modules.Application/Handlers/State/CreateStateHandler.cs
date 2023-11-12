﻿using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Handlers.State.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using CloudSuite.Modules.Application.Validations.State;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CreateStateHandler : IRequestHandler<CreateStateCommand, CreateStateResponse>
    {
        private readonly IStateRepository _stateRepository;
        private readonly ILogger<CreateStateHandler> _logger;

        public CreateStateHandler(IStateRepository stateRepository, ILogger<CreateStateHandler> logger)
        {
            _stateRepository = stateRepository;
            _logger = logger;
        }

        public async Task<CreateStateResponse> Handle(CreateStateCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateStateCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateStateCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var stateName = await _stateRepository.GetByName(command.StateName);
                    var mediaFileName = await _stateRepository.GetByUF(command.UF);

                    if (stateName != null && mediaFileName != null)
                    {
                        return await Task.FromResult(new CreateStateResponse(command.Id, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateStateResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateStateResponse(command.Id, validationResult));

        }
    }
}
