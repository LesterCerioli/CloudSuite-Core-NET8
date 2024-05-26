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
        public Cnpj Cnpj { get; set; }
        public string FantasyName { get; set; }
        public string RegisterName { get; set; }

        public Company() { } // Construtor sem parâmetros

        public Company(Cnpj cnpj, string fantasyName, string registerName)
        {
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
        }


    }
}