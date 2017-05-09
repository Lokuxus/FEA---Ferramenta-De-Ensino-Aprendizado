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

    public class CadastroNodoViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Questao")]
        public string questao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Resposta A")]
        public string respostaA { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Resposta B")]
        public string respostaB { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Resposta C")]
        public string respostaC { get; set; }

        public string idArvore { get; set; }


    }

}


