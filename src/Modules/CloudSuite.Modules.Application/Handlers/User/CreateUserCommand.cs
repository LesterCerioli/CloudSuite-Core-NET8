using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = CloudSuite.Domain.Models.User;

namespace CloudSuite.Modules.Application.Handlers.User
{
	public class CreateUserCommand : IRequest<CreateUserResponse>
	{
		public Guid Id { get; private set; }

		public string? FullName { get; set; }

		public string? Cpf { get; set; }

		public string? Email { get; set; }

		public string? Telephone { get; set; }


		public bool? IsDeleted { get; set; }

		public DateTimeOffset? CreatedOn { get; set; }

		public DateTimeOffset? LatestUpdatedOn { get; set; }

		public CreateUserCommand()
		{
			Id = Guid.NewGuid();
		}

		public UserEntity GetEntity()
		{
			return new UserEntity(
				this.FullName,
				new Cpf(this.Cpf),
				this.Email,
				this.IsDeleted.Value,
				this.CreatedOn
				);
		}
	}
}
