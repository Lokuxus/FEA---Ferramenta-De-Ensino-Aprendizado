using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEA.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }
    }
}