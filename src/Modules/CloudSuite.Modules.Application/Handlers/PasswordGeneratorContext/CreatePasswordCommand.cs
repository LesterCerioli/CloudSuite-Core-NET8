

using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordEntity = CloudSuite.Domain.Models.PasswordGeneratorContext.Password;


namespace CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext
{
	public class CreatePasswordCommand : IRequest<CreatePasswordRespnse>
    {
        public Guid Id { get; private set; }

        public string? Senha { get; set; }

        public int? CaracterNumber { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public CreatePasswordCommand()
        {
            Id = Guid.NewGuid();
        }

        public PasswordEntity GetEntity()
        {
            return new PasswordEntity(

                this.Senha,
                this.CaracterNumber,
                this.CreatedOn);
        }

        
    }
}
