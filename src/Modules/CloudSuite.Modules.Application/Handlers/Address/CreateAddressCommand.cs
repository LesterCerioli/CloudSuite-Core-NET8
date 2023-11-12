using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using AddressEntity = CloudSuite.Domain.Models.Address;
using CityEntity = CloudSuite.Domain.Models.City;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CreateAddressCommand : IRequest<CreateAddressResponse>
    {
            public Guid Id { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            [StringLength(100)]
            public string? ContactName { get; private set; }

            [Required(ErrorMessage = "The {0} field is required.")]
            [StringLength(450)]
            public string? AddressLine1 { get; private set; }

            public CityEntity City { get; private set; }

            public District District { get; private set; }

            public Guid DistrictId { get; private set; }

            public AddressEntity GetEntity()
            {
                return new AddressEntity(
                    this.Id,
                    this.City,
                    this.District,
                    this.ContactName,
                    this.AddressLine1
                    );
            }
        }

    }