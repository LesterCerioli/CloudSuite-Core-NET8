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
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; private set; }

        public Cnpj Cnpj { get; private set; }

        public Guid CnpjId { get; private set; }

        public EmailEntity Email { get; private set; }

        public Guid EmailId { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        public bool? IsActive { get; private set; }

        public bool? IsDeleted { get; private set; }

        public UserEntity User { get; private set; }

        public Guid UserId { get; private set; }



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
