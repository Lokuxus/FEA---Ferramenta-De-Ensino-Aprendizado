using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FEA.Models
{
    public class RegisterQuestaoViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Questao")]
        public string Questao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Resposta")]
        public string Resposta { get; set; }

    }
}