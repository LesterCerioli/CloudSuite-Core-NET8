using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Request
{
    public class CheckVendorExistsByCreatedOnRequest : IRequest<CheckVendorExistsByCreatedOnResponse>
    {
        public Guid Id { get; set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public CheckVendorExistsByCreatedOnRequest(DateTimeOffset createdOn)
        {
            Id = Guid.NewGuid();
            CreatedOn = createdOn;
        }

        public CheckVendorExistsByCreatedOnRequest() { }
    }
}
