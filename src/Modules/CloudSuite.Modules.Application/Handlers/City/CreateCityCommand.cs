using CloudSuite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CityEntity = CloudSuite.Domain.Models.City;

namespace CloudSuite.Modules.Application.Hadlers.City
{
    public class CreateCityCommand : IRequest<CreateCityResponse>
    {

        public Guid Id { get; set; }
        
        public string? CityName { get; private set; }

        public CreateCityCommand()
        {
            Id = Guid.NewGuid();
        }

		public CityEntity GetEntity()
        {
            return new CityEntity(
                
                this.CityName
                
                );
        }
    }
}
