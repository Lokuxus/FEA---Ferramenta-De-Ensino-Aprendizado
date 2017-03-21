using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FEA.Models
{
    public class CadastroArvoreViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Matéria")]
        public string Materia { get; set; }
    }

}
