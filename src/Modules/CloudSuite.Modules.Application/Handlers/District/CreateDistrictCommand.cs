using CloudSuite.Modules.Application.Handlers.District.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using DistrictEntity = CloudSuite.Domain.Models.District;
using StateEtinty = CloudSuite.Domain.Models.State;

namespace CloudSuite.Modules.Application.Handlers.District
{
    public class CreateDistrictCommand : IRequest<CreateDistrictResponse>
    {
        public Guid Id { get; set; }
        public StateEtinty State { get; set; }

        public Guid StateId { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? Type { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Location { get; private set; }


        public DistrictEntity GetEntity()
        {
            return new DistrictEntity(
                this.Id,
                this.Name,
                this.Type,
                this.Location
                );
        }
    }
}
