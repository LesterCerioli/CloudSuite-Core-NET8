using CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.PasswordGeneratorContext.Requests
{
    public class CheckPasswordExistsBySenhaRequest : IRequest<CheckPasswordExistsBySenhaResponse>
    {
        public CheckPasswordExistsBySenhaRequest(Guid id, string? senha)
        {
            Id = id;
            Senha = senha;
        }

        public Guid Id { get; private set; }

        public string? Senha { get; set; }
    }
}
