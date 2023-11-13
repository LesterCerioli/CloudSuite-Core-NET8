using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Media.Request
{
    public class CheckMediaExistsByFileSizeRequest : IRequest<CheckMediaExistsByFileSizeResponse>
    {
        public Guid Id { get; set; }

        public int? FileSize { get; set; }

        public CheckMediaExistsByFileSizeRequest(int fileSize)
        {
            Id = Guid.NewGuid();
            FileSize = fileSize;
        }

        public CheckMediaExistsByFileSizeRequest() { }
    }
}
