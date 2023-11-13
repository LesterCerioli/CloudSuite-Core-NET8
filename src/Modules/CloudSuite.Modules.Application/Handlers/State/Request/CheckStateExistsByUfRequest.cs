using CloudSuite.Modules.Application.Handlers.State.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.State.Request
{
    public class CheckStateExistsByUfRequest : IRequest<CheckStateExistsByUfResponse>
    {
        public Guid Id { get; set; }

        public string? UF { get; private set; }

        public CheckStateExistsByUfRequest(string uf)
        {
            Id = Guid.NewGuid();
            UF = uf;
        }

        public CheckStateExistsByUfRequest() { }
    }
}
