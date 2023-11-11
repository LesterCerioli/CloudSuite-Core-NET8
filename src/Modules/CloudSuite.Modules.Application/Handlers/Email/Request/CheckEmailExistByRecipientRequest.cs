using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Email.Request
{
    public class CheckEmailExistByRecipientRequest : IRequest<CheckEmailExistByRecipientResponse>
    {
        public Guid Id { get; set; }

        public string? Recipient { get; private set; }

        public CheckEmailExistByRecipientRequest(string recipient)
        {
            Id = Guid.NewGuid();
            Recipient = recipient;
        }

        public CheckEmailExistByRecipientRequest() { }
    }
}
