using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using UserEntity = CloudSuite.Domain.Models.User;
using EmailEntity = CloudSuite.Domain.Models.Email;
using VendorEntity = CloudSuite.Domain.Models.Vendor;


namespace CloudSuite.Modules.Application.Handlers.User
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {

        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? FullName { get; set; }

        public EmailEntity Email { get; set; }

        public string? Cpf { get; set; }

        public string? Telephone { get; set; }

        public VendorEntity Vendor { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        [StringLength(450)]
        public string? RefreshTokenHash { get; set; }

        [StringLength(450)]
        public string? Culture { get; set; }

        public string? ExtensionData { get; set; }

        public Guid VendorId { get; set; }


        public UserEntity GetEntity()
        {
            return new UserEntity(
                this.FullName,
                new Cpf(this.Cpf),
                this.IsDeleted.Value,
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.RefreshTokenHash,
                this.Culture,
                this.ExtensionData
                );
        }

    }
}
