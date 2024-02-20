using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using VendorEntity = CloudSuite.Domain.Models.Vendor;
using EmailEntity = CloudSuite.Domain.Models.Email;
using UserEntity = CloudSuite.Domain.Models.User;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CreateVendorCommand : IRequest<CreateVendorResponse>
    {
        public Guid Id { get; private set; }

        public string? Name { get; set; }

        public string? Slug { get; set; }

        public string? Description { get; set; }

        public Cnpj Cnpj { get; set; }

        public Guid CnpjId { get; set; }

        public EmailEntity Email { get; set; }

        public Guid EmailId { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public UserEntity User { get; set; }

        public Guid UserId { get; set; }

        public CreateVendorCommand()
        {
            Id = Guid.NewGuid();
        }

        public VendorEntity GetEntity()
        {
            return new VendorEntity(
                this.UserId,
                this.Name,
                this.Slug,
                this.Description,
                this.Cnpj,
                this.Email,
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.IsActive,
                this.IsDeleted
                );
        }
    }
}
