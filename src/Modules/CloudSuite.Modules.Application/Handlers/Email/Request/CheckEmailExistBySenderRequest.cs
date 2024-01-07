using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Email.Request
{
    public class CheckEmailExistBySenderRequest : IRequest<CheckEmailExistBySenderResponse>
    {
        public Guid Id { get; set; }

        public string? Sender { get; set; }

        public CheckEmailExistBySenderRequest(string? sender)
        {
            Id = Guid.NewGuid();
            Sender = sender;
        }
        public CheckEmailExistBySenderRequest()
        {

        }
    }
}
