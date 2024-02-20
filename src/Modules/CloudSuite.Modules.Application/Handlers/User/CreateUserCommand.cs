using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using UserEntity = CloudSuite.Domain.Models.User;
using EmailEntity = CloudSuite.Domain.Models.Email;


namespace CloudSuite.Modules.Application.Handlers.User
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {

        public Guid Id { get; private set; }

        public string? FullName { get; set; }

        public EmailEntity Email { get; set; }

        public string Cpf { get; set; }

        public string Telephone { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public string? RefreshTokenHash { get; set; }

        public Guid VendorId { get; set; }

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public UserEntity GetEntity()
        {
            return new UserEntity(
                this.FullName,
                this.Email,
                new Cpf(this.Cpf),
                new Telephone(this.Telephone),
                this.IsDeleted,
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.RefreshTokenHash
                );
        }

    }
}
