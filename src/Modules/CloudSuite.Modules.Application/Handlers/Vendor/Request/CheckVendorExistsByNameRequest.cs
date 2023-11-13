using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;

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
