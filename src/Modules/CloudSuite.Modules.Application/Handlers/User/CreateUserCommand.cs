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

        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string? FullName { get; private set; }

        public EmailEntity Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public Telephone Telephone { get; private set; }

        public VendorEntity Vendor { get; private set; }

        public bool? IsDeleted { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        [StringLength(450)]
        public string? RefreshTokenHash { get; private set; }

        [StringLength(450)]
        public string? Culture { get; private set; }

        public string? ExtensionData { get; private set; }

        public Guid VendorId { get; private set; }


        public UserEntity GetEntity()
        {
            return new UserEntity(
                this.FullName,
                this.Email,
                this.Cpf,
                this.Telephone,
                this.Vendor,
                this.IsDeleted,
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.RefreshTokenHash,
                this.Culture,
                this.ExtensionData
                );
        }

    }
}
