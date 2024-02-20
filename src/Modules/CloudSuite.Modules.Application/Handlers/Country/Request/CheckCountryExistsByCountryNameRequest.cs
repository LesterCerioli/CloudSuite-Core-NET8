using CloudSuite.Modules.Application.Handlers.Country.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Country.Request
{
    public class CheckCountryExistsByCountryNameRequest : IRequest<CheckCountryExistsByCountryNameResponse>
    {
        public Guid Id { get; private set; }

        public string? CountryName { get; set; }

        public CheckCountryExistsByCountryNameRequest(string countryName)
        {
            Id = Guid.NewGuid();
            CountryName = countryName;
        }

    }
}
