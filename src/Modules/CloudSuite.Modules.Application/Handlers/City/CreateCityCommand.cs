using CloudSuite.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CityEntity = CloudSuite.Domain.Models.City;

namespace CloudSuite.Modules.Application.Hadlers.City
{
    public class CreateCityCommand : IRequest<CreateCityResponse>
    {

        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(100)]

        public string? CityName { get; private set; }

        public State State { get; private set; }

        public Guid StateId { get; private set; }



        public CityEntity GetEntity()
        {
            return new CityEntity(
                this.StateId,
                this.CityName,
                this.State
                );
        }
    }
}
