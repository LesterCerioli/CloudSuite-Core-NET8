using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Request
{
    public class CheckVendorExistsByCreationDateRequest : IRequest<CheckVendorExistsByCreationDateResponse>
    {
        public Guid Id { get; set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public CheckVendorExistsByCreationDateRequest(DateTimeOffset createdOn)
        {
            Id = Guid.NewGuid();
            CreatedOn = createdOn;
        }

        public CheckVendorExistsByCreationDateRequest() { }
    }
}
