using CloudSuite.Modules.Application.Handlers.Company.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Company.Request
{
    public class CheckCompanyExistsByRegisterNameRequest : IRequest<CheckCompanyExistsByRegisterNameResponse>
    {
        public Guid Id { get; private set; }

        public string? RegisterName { get; set; }

        public CheckCompanyExistsByRegisterNameRequest(string registerName)
        {
            Id = Guid.NewGuid();
            RegisterName = registerName;
        }

    }
}
