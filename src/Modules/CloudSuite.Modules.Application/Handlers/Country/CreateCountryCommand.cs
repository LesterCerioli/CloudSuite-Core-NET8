using CloudSuite.Modules.Application.Handlers.Country.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CountryEntity = CloudSuite.Domain.Models.Country;

namespace CloudSuite.Modules.Application.Handlers.Country
{
    public class CreateCountryCommand : IRequest<CreateCountryResponse>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? CountryName { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Code3 { get; private set; }

        public bool? IsBillingEnabled { get; private set; }

        public bool? IsShippingEnabled { get; private set; }

        public bool? IsCityEnabled { get; private set; }

        public bool? IsZipCodeEnabled { get; private set; }

        public bool? IsDistrictEnabled { get; private set; }

        public Guid StateId { get; private set; }




        public CountryEntity GetEntity()
        {
            return new CountryEntity(
                this.Id,
                this.CountryName,
                this.Code3,
                this.IsBillingEnabled,
                this.IsShippingEnabled,
                this.IsCityEnabled,
                this.IsZipCodeEnabled,
                this.IsDistrictEnabled
                );
        }
    }
}
