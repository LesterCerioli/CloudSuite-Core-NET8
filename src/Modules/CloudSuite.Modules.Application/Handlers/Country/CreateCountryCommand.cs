using CloudSuite.Modules.Application.Handlers.Country.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CountryEntity = CloudSuite.Domain.Models.Country;

namespace CloudSuite.Modules.Application.Handlers.Country
{
    public class CreateCountryCommand : IRequest<CreateCountryResponse>
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? CountryName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Code3 { get; set; }

        public bool? IsBillingEnabled { get; set; }

        public bool? IsShippingEnabled { get; set; }

        public bool? IsCityEnabled { get; set; }

        public bool? IsZipCodeEnabled { get; set; }

        public bool? IsDistrictEnabled { get; set; }

        public Guid StateId { get; set; }

        public CreateCountryCommand()
        {
            Id = Guid.NewGuid();
        }


        public CountryEntity GetEntity()
        {
            return new CountryEntity(
                this.Id,
                this.CountryName,
                this.Code3,
                this.IsBillingEnabled.Value,
                this.IsShippingEnabled.Value,
                this.IsCityEnabled.Value,
                this.IsZipCodeEnabled.Value,
                this.IsDistrictEnabled.Value
                );
        }
    }
}
