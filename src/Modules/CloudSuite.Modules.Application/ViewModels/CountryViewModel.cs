using CloudSuite.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
	public class CountryViewModel
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "The {0} field is required.")]
		[StringLength(450)]
		[DisplayName("Nome País")]
		public string CountryName { get; set; }

		[Required(ErrorMessage = "The field is required.")]
		[StringLength(450)]
		[DisplayName("Código")]
		public string Code3 { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("Pagamento habilitado")]
        public bool? IsBillingEnabled { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("envio habilitado")]
        public bool? IsShippingEnabled { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("cidade habilitada")]
        public bool? IsCityEnabled { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("Cep Habilitado")]
        public bool? IsZipCodeEnabled { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("Distrito habilitado")]
        public bool? IsDistrictEnabled { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        [StringLength(450)]
        [DisplayName("id do distrito")]
        public Guid StateId { get; set; }
    }
}
