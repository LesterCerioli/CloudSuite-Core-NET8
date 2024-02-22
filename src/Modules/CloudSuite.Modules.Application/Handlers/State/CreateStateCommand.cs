using MediatR;
using StateEntity = CloudSuite.Domain.Models.State;
using CloudSuite.Modules.Application.Handlers.State.Responses;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CreateStateCommand : IRequest<CreateStateResponse>
    {
        public Guid Id { get; private set; }

        public string? StateName { get; set; }

        public string? UF { get; set; }

        public CreateStateCommand()
        {
            Id = Guid.NewGuid();
        }

        public StateEntity GetEntity()
        {
            return new StateEntity(
                this.UF,
                this.StateName
                );
        }

    }
}
