using NetDevPack.Domain;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models
{
    public class Company : Entity, IAggregateRoot
    {
        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName, Address address) {
            AddressId = id;
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
            Address = address;
        }

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
    }
}