using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using MediaEntity = CloudSuite.Domain.Models.Media;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CreateMediaCommand : IRequest<CreateMediaResponse>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(450)]
        public string? Caption { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int? FileSize { get; set; }

        [Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
        [StringLength(450)]
        public string? FileName { get; set; }

        public MediaType MediaType { get; set; }


        public MediaEntity GetEntity()
        {
            return new MediaEntity(
                this.Id,
                this.Caption,
                this.FileSize,
                this.FileName,
                this.MediaType
                );
        }

    }
}
