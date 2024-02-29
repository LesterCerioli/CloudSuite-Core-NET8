using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using VendorEntity = CloudSuite.Domain.Models.Vendor;
using EmailEntity = CloudSuite.Domain.Models.Email;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CreateVendorCommand : IRequest<CreateVendorResponse>
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; set; }

        public string? Cnpj { get; set; }

        public EmailEntity Email { get; set; }

        public Guid EmailId {  get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid UserId { get; private set; }



        public VendorEntity GetEntity()
        {
            return new VendorEntity(
                this.UserId,
                this.Name,
                this.Slug,
                this.Description,
                new Cnpj(this.Cnpj),
                this.EmailId,
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.IsActive.Value,
                this.IsDeleted.Value
                );
        }
    }
}
