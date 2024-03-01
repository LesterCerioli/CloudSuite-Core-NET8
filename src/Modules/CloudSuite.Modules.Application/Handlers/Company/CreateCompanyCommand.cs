using CloudSuite.Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CompanyEntity = CloudSuite.Domain.Models.Company;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyCommand : IRequest<CreateCompanyResponse>
    {
        public Guid Id { get; private set; }

        public string? Cnpj { get; set; }
        public Guid CnpjID { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string? FantasyName { get; set; }

        [Required(ErrorMessage = "Este campo é de preencimento obrigatório.")]
        [MaxLength(100)]
        public string? RegisterName { get; set; }

        public Guid AddressId { get; set; }

        public CreateCompanyCommand()
        {
            Id = Guid.NewGuid();
        }

        public CompanyEntity GetEntity()
        {
            return new CompanyEntity(
                   this.AddressId,
                   new Cnpj(this.Cnpj),
                   this.FantasyName,
                   this.RegisterName
                );
        }

    }
}
