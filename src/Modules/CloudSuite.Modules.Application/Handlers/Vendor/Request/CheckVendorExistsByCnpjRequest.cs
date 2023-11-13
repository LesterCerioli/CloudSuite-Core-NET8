using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Request
{
    public class CheckVendorExistsByCnpjRequest : IRequest<CheckVendorExistsByCnpjResponse>
    {
        public Guid Id { get; set; }

        public Cnpj Cnpj { get; private set; }

        public CheckVendorExistsByCnpjRequest(string cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }

        public CheckVendorExistsByCnpjRequest() { }
    }
}
