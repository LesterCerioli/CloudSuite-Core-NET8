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

        public Company() { }

        public Cnpj Cnpj { get; private set; }

        public string? FantasyName { get; private set; }

        public string? RegisterName { get; private set; }

        public Address Address { get; private set; }

        public Guid AddressId { get; private set; }
    }
}