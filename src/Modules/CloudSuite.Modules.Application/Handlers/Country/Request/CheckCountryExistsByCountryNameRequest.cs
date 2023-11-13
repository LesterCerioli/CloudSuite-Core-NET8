using CloudSuite.Modules.Application.Handlers.Country.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Country.Request
{
    public class CheckCountryExistsByCountryNameRequest : IRequest<CheckCountryExistsByCountryNameResponse>
    {
        public Guid Id { get; set; }

        public string? CountryName { get; private set; }

        public CheckCountryExistsByCountryNameRequest(string countryName)
        {
            Id = Guid.NewGuid();
            CountryName = countryName;
        }

        public CheckCountryExistsByCountryNameRequest() { }
    }
}
