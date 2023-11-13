using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.State.Request;
using CloudSuite.Modules.Application.Handlers.State.Responses;
using CloudSuite.Modules.Application.Validations.State;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CheckStateExistsByUfHandler : IRequestHandler<CheckStateExistsByUfRequest, CheckStateExistsByUfResponse>
    {
        private readonly IStateRepository _stateRepository;
        private readonly ILogger<CheckStateExistsByUfHandler> _logger;

        public CheckStateExistsByUfHandler(IStateRepository stateRepository, ILogger<CheckStateExistsByUfHandler> logger)
        {
            _stateRepository = stateRepository;
            _logger = logger;
        }

        public async Task<CheckStateExistsByUfResponse> Handle(CheckStateExistsByUfRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckStateExistsByUfRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckStateExistsByUfRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var stateUf = await _stateRepository.GetByUF(request.UF);

                    if (stateUf != null)
                    {
                        return await Task.FromResult(new CheckStateExistsByUfResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckStateExistsByUfResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckStateExistsByUfResponse(request.Id, false, validationResult));

        }
    }
}
