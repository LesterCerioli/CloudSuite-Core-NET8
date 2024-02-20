using CloudSuite.Modules.Application.Handlers.User.Responses;
using MediatR;
using EmailEntity = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Handlers.User.Request
{
    public class CheckUserExistsByEmailRequest : IRequest<CheckUserExistsByEmailResponse>
    {
        public Guid Id { get; private set; }

        public EmailEntity Email { get; set; }

        public CheckUserExistsByEmailRequest(EmailEntity email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }

    }
}

