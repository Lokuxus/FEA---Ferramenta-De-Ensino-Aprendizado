using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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

        public ActionResult Nodos(string Arvore)
        {
            var retornarSQL = MateriaModel.BuscaListaNodo(arvore: Arvore);
            DataTable table1 = new DataTable("Arvore");
            table1.Columns.Add("arvore");
            table1.Rows.Add(Arvore);
            retornarSQL.Tables.Add(table1);


            return View("Nodos", retornarSQL);
        }

        public ActionResult CadastroArvore()
        {
            return View();
            // return RedirectToAction("SalvaCadastroArvore");
        }

        public ActionResult CadastroNodo(string arvore)
        {
            ViewBag.arvore = arvore;
            return View("CadastroNodo", arvore);
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
        public ActionResult SalvaNodoArvore(string arvore, string nome)
        {
            var cad_materia = new CadastroMateriaModel.MateriaModel();
            var retorno = cad_materia.Cadastra_Nodo(arvore: arvore, nome: nome);

            return RedirectToAction("Arvores");

        }

        [HttpGet]
        public ActionResult DeletaMateria(string idMateria)
        {
            var conexao = new CadastroMateriaModel.MateriaModel();

            var retorno = conexao.Deleta_Materia(id: idMateria);

            
            return RedirectToAction("Arvores");
        }

        public ActionResult DeletaNodo(string idNodo, string Arvore)
        {
            var conexao = new CadastroMateriaModel.MateriaModel();

            var retorno = conexao.Deleta_Nodo(id: idNodo);

            return RedirectToAction("Nodos", Arvore);
        }


    }
}