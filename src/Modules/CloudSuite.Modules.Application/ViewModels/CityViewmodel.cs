

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModel
{
    public class CityViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatario.")]
        [MaxLength(100)]
        [DisplayName("NomeCidade")]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatario.")]
        [MaxLength(100)]
        [DisplayName("Estado")]
        public string? State { get; set; }
    }
}