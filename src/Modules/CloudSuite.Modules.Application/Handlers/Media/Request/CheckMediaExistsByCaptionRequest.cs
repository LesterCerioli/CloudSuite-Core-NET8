using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Media.Request
{
    public class CheckMediaExistsByCaptionRequest : IRequest<CheckMediaExistsByCaptionResponse>
    {
        public Guid Id { get; set; }

        public string? Caption { get; set; }

        public CheckMediaExistsByCaptionRequest(string caption)
        {
            Id = Guid.NewGuid();
            Caption = caption;
        }

        public CheckMediaExistsByCaptionRequest() { }
    }
}
