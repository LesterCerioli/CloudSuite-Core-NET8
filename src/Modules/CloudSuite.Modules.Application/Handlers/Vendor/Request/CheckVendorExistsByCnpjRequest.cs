using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Vendor.Request
{
    public class CheckVendorExistsByCnpjRequest : IRequest<CheckVendorExistsByCnpjResponse>
    {
        public Guid Id { get; private set; }

        public Cnpj Cnpj { get; set; }

        public CheckVendorExistsByCnpjRequest(string cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }
    }
}
