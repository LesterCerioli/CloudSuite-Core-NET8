using CloudSuite.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Company.Request
{
    public class CheckCompanyExistsByCnpjRequest : IRequest<CheckCompanyExistsByCnpjResponse>
    {
        public Guid Id { get; set; }

        public Cnpj Cnpj { get; set; }

        public CheckCompanyExistsByCnpjRequest(string cnpj)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
        }

        public CheckCompanyExistsByCnpjRequest() { }
    }
}
