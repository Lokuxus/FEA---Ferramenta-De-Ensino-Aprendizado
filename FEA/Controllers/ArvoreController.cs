using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FEA.CadastroMateriaModel;

namespace FEA.Controllers
{
    public class ArvoreController : Controller
    {
        // GET: Lista
        public ActionResult Arvores()
        {
            return View();
        }

        public ActionResult CadastroArvore(string materia, string turma )
        {
            var cad_materia = new CadastroMateriaModel.CadastroMateriaModel();
            cad_materia.Cadastra_Materia(materia, turma);
            
            return View();
        }

    }
}