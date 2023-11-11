using CloudSuite.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
