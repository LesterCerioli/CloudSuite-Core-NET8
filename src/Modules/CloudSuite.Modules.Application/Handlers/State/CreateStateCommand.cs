using MediatR;
using System.ComponentModel.DataAnnotations;
using StateEntity = CloudSuite.Domain.Models.State;
using CountryEntity = CloudSuite.Domain.Models.Country;
using CloudSuite.Modules.Application.Handlers.State.Responses;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CreateStateCommand : IRequest<CreateStateResponse>
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(100)]
        public string? StateName { get; set; }

        [Required(ErrorMessage = "Este cmapo é de preenchimento obrigatório.")]

        public string? UF { get; set; }

        public CountryEntity Country { get; set; }

        public Guid CountryId { get; set; }


        public StateEntity GetEntity()
        {
            return new StateEntity(
                this.Id,
                this.UF,
                this.StateName,
                this.CountryId
                );
        }

    }
}
