using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class UserViewModel
	{
		[Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(100)]
        [DisplayName("Nome Completo")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(100)]
        [DisplayName("Email")]
		public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório.")]
        [StringLength(100)]
        [DisplayName("Cpf")]
		public string Cpf { get; set; }

		[DisplayName("Telefone")]
		public string Telephone { get; set; }

		[DisplayName("Data Criacao")]
		public DateTimeOffset CreatedOn { get; set; }

		[DisplayName("Data Atualizacao")]
		public DateTimeOffset LatestUpdatedOn { get; set; }	
		
	}
}
