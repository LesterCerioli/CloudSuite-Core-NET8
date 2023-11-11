using CloudSuite.Modules.Application.Handlers.Email.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
