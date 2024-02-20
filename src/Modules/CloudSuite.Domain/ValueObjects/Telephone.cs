﻿using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Domain.ValueObjects
{
    public class Telephone : ValueObject
    {
        private string telefone;

        public Telephone(string? telephoneNumber)
        {
            this.telefone = telephoneNumber;
        }
        public string TelephoneNumber { get; private set; }

        public string TelephoneRegion { get; private set; }


        public static bool ValidarTelefone(string telefone)
        {
            string shortenNum = Regex.Replace(telefone, @"[^0-9a-zA-Z]+", "");

            if (telefone.Length == 13)
            {
                Console.WriteLine("O número de telefone é válido");
                return true;
            }

            else
            {
                Console.Write("O número de telefone é inválido");
                return false;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }

}
