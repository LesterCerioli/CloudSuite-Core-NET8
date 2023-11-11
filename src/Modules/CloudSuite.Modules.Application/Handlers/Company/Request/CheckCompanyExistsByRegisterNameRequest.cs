using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Company.Request
{
    public class CheckCompanyExistsByRegisterNameRequest : IRequest<CheckCompanyExistsByRegisterNameResponse>
    {
        public Guid Id { get; private set; }
        public string? RegisterName { get; private set; }

        public CheckCompanyExistsByRegisterNameRequest(string registerName)
        {
            Id = Guid.NewGuid();
            RegisterName = registerName;
        }

        public CheckCompanyExistsByRegisterNameRequest() { }
    }
}
