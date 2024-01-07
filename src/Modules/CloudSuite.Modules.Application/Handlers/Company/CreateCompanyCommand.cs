using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CompanyEntity = CloudSuite.Domain.Models.Company;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyCommand : IRequest<CreateCompanyResponse>
    {
        public Guid Id { get; set; }

        public Cnpj Cnpj { get; set; }

        public Guid CnpjID { get; private set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string? FantasyName { get; private set; }

        [Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
        [MaxLength(100)]
        public string? RegisterName { get; private set; }

        public Address Address { get; private set; }

        public Guid AddressId { get; private set; }


        public CompanyEntity GetEntity()
        {
            return new CompanyEntity(
                   this.AddressId,
                   this.Cnpj,
                   this.FantasyName,
                   this.RegisterName,
                   this.Address
                );
        }

    }
}
