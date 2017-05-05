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
            var retornarSQL = MateriaModel.BuscaListaMateria();
            
            return View("Arvores", retornarSQL);
        }

        public ActionResult CadastroArvore()
        {
            return View();
            // return RedirectToAction("SalvaCadastroArvore");
        }

        [HttpGet]
        public ActionResult SalvaCadastroArvore(string materia, string turma)
        {
            var cad_materia = new CadastroMateriaModel.MateriaModel();
            var retorno = cad_materia.Cadastra_Materia(materia: materia, turma: turma);

            return RedirectToAction("Arvores");

        }
        [HttpGet]
        public ActionResult DeletaMateria(string idMateria)
        {
            var conexao = new CadastroMateriaModel.MateriaModel();

            var retorno = conexao.Deleta_Materia(id: idMateria);

            
            return RedirectToAction("Arvores");
        }


    }
}