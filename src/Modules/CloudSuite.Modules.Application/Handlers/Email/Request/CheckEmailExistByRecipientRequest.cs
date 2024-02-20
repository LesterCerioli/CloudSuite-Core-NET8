using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Email.Request
{
    public class CheckEmailExistByRecipientRequest : IRequest<CheckEmailExistByRecipientResponse>
    {
        public Guid Id { get; private set; }

        public string? Recipient { get; set; }

        public CheckEmailExistByRecipientRequest(string recipient)
        {
            Id = Guid.NewGuid();
            Recipient = recipient;
        }

    }
}
