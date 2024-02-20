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

            public string? ContactName { get; set; }

            public string? AddressLine1 { get; set; }

            public CityEntity City { get; set; }

            public District District { get; set; }

            public Guid DistrictId { get; set; }

            public CreateAddressCommand()
            {
                Id = Guid.NewGuid();
            }
            
            public AddressEntity GetEntity(){
                    
                return new AddressEntity(
                        this.City,
                        this.District,
                        this.ContactName,
                        this.AddressLine1
                        );
            }
        }

    }