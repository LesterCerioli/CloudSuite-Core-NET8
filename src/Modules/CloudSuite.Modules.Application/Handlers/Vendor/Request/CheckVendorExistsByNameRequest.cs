using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Request
{
    public class CheckVendorExistsByNameRequest : IRequest<CheckVendorExistsByNameResponse>
    {
        public Guid Id { get; set; }

        public string? Name { get; private set; }

        public CheckVendorExistsByNameRequest(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public CheckVendorExistsByNameRequest() { }
    }
}
