using CloudSuite.Modules.Application.Handlers.District.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.District.Request
{
    public class CheckDistrictExistsByNameRequest : IRequest<CheckDistrictExistsByNameResponse>
    {
        public Guid Id { get; set; }

        public string? Name { get; private set; }

        public CheckDistrictExistsByNameRequest(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public CheckDistrictExistsByNameRequest() { }
    }
}
