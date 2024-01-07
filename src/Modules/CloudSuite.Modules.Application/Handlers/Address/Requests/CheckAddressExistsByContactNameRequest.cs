using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Hadlers.Address.Requests
{
    public class CheckAddressExistsByContactNameRequest : IRequest<CheckAddressExistsByContactNameResponse>
    {
        public Guid Id { get; private set; }

        public string? ContactName { get; private set; }

        public CheckAddressExistsByContactNameRequest(string contactName)
        {
            Id = Guid.NewGuid();
            ContactName = contactName;
        }

        public CheckAddressExistsByContactNameRequest() { }
    }
}
