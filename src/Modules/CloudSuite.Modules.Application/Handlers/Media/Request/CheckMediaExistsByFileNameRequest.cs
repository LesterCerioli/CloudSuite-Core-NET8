using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Media.Request
{
    public class CheckMediaExistsByFileNameRequest : IRequest<CheckMediaExistsByFileNameResponse>   
    {
        public Guid Id { get; set; }

        public string? FileName { get; set; }

        public CheckMediaExistsByFileNameRequest(string fileName)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
        }

        public CheckMediaExistsByFileNameRequest() { }
    }
}
