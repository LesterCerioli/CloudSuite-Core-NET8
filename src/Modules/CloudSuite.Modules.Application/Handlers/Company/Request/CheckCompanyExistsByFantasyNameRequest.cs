using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.Company.Request
{
    public class CheckCompanyExistsByFantasyNameRequest : IRequest<CheckCompanyExistsByFantasyNameResponse>
    {
        public Guid Id { get; private set; }
        public string? FantasyName { get; private set; }

        public CheckCompanyExistsByFantasyNameRequest(string fantasyName)
        {
            Id = Guid.NewGuid();
            FantasyName = fantasyName;
        }

        public CheckCompanyExistsByFantasyNameRequest() { }
    }

}
