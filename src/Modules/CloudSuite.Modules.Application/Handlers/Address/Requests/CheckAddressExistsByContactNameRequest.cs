using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Hadlers.Address.Requests
{
    public class CheckAddressExistsByContactNameRequest : IRequest<CheckAddressExistsByContactNameResponse>
    {
        public Guid Id { get; private set; }

        public string? ContactName { get; private set; }

        public CheckAddressExistsByContactNameRequest(string contactName)
        {
            Id = Guid.NewGuid();
            ContactName = contactName;
        }

        public CheckAddressExistsByContactNameRequest() { }
    }
}
