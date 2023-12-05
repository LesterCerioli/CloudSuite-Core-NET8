using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using MediaEntity = CloudSuite.Domain.Models.Media;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CreateMediaCommand : IRequest<CreateMediaResponse>
    {
        public Guid Id { get; private set; }
                
        public string? Caption { get; private set; }

        public int? FileSize { get; private set; }

        public string? FileName { get; private set; }

        public CreateMediaCommand()
        {
            Id = Guid.NewGuid();
        }


		public MediaEntity GetEntity()
        {
            return new MediaEntity(
                
                this.Caption,
                this.FileSize,
                this.FileName
                
                );
        }

    }
}
