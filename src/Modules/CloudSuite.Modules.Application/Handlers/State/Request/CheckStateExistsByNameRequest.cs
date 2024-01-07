using CloudSuite.Modules.Application.Handlers.State.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.State.Request
{
    public class CheckStateExistsByNameRequest : IRequest<CheckStateExistsByNameResponse>
    {
        public Guid Id { get; private set; }

        public string? StateName { get; private set; }

        public CheckStateExistsByNameRequest(string stateName)
        {
            Id = Guid.NewGuid();
            StateName = stateName;
        }

        public CheckStateExistsByNameRequest() { }
    }
}
