using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;
using AddressEntity = CloudSuite.Domain.Models.Address;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CreateAddressCommand : IRequest<CreateAddressResponse>
    {
            public Guid Id { get; private set; }

            public string? ContactName { get; set; }

            public string? AddressLine1 { get; set; }

            public CreateAddressCommand()
            {
                Id = Guid.NewGuid();
            }
            
            public AddressEntity GetEntity(){
                    
                return new AddressEntity(
                        this.ContactName,
                        this.AddressLine1
                        );
            }
        }

    }