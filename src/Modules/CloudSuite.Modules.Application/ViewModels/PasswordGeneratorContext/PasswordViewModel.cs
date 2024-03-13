using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels.PasswordGeneratorContext
{
    public class PasswordViewModel
    {
        [Key]
        public Guid Id { get; private set; }


        [DisplayName("Senha")]
        [MinLength(24)]
        public string? Senha { get; set; }


        [DisplayName("CaracterNumero")]
        [MinLength(24)]
        public int? CaracterNumber { get; set; }

        [DisplayName("DataCriacao")]
        public DateTimeOffset? CreatedOn { get; set; }
    }
}
