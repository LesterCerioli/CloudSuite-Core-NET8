using CloudSuite.Modules.Application.Handlers.Country.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Country.Request
{
    public class CheckCountryExistsByCodeRequest : IRequest<CheckCountryExistsByCodeResponse>
    {
        public Guid Id { get; set; }

        public string? Code3 { get; private set; }

        public CheckCountryExistsByCodeRequest(string code3)
        {
            Id = Guid.NewGuid();
            Code3 = code3;
        }

        public CheckCountryExistsByCodeRequest() { }
    }
}
