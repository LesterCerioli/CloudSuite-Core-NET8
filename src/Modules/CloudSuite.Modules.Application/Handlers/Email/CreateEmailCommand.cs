using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;
using EmailEntity = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Handlers.Email
{
    public class CreateEmailCommand : IRequest<CreateEmailResponse>
    {
        public Guid Id { get; set; }
        public string? Subject { get; private set; }

        public string? Body { get; private set; }

        public string? Sender { get; private set; }

        public string? Recipient { get; private set; } 

        public DateTimeOffset? SentDate { get; private set; } 

        public bool? IsRead { get; private set; }

        public int? SendAttempts { get; private set; }

        public CodeErrorEmail CodeErrorEmail { get; private set; }


        public EmailEntity GetEntity()
        {
            return new EmailEntity(
                this.Subject,
                this.Body,
                this.Sender,
                this.Recipient,
                this.SentDate,
                this.IsRead
                );
        }

    }
}
