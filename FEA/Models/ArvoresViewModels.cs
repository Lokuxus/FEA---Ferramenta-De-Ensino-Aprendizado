using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FEA.Models
{
    public class CadastroArvoreViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "materia")]
        public string materia { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Turma")]
        public string turma { get; set; }
    }

}
