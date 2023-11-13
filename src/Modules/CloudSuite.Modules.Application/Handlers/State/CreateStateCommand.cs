using MediatR;
using System.ComponentModel.DataAnnotations;
using StateEntity = CloudSuite.Domain.Models.State;
using CountryEntity = CloudSuite.Domain.Models.Country;
using CloudSuite.Modules.Application.Handlers.State.Responses;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CreateStateCommand : IRequest<CreateStateResponse>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(100)]
        public string? StateName { get; private set; }

        [Required(ErrorMessage = "Este cmapo é de preenchimento obrigatório.")]

        public string? UF { get; private set; }

        public CountryEntity Country { get; private set; }

        public Guid CountryId { get; private set; }


        public StateEntity GetEntity()
        {
            return new StateEntity(
                this.Id,
                this.UF,
                this.StateName,
                this.Country,
                this.CountryId
                );
        }

    }
}
