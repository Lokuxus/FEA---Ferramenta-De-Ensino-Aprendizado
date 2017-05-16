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
        public static string _idArvore;
        public static string _nome;
        // GET: Lista
        public ActionResult Arvores()
        {
            var retornarSQL = MateriaModel.BuscaListaMateria();
            
            return View("Arvores", retornarSQL);
        }

        public ActionResult Nodos(string Arvore, string nome)
        {
            _idArvore = Arvore;
            _nome = nome;
            ViewBag.idAvore = Arvore;

            var retornarSQL = MateriaModel.BuscaListaNodo(arvore: Arvore);
            DataTable nodos = new DataTable("Arvore");
            nodos.Columns.Add("arvore");
            nodos.Rows.Add(nome);
            retornarSQL.Tables.Add(nodos);
 
            return View("Nodos", retornarSQL);
        }

        public ActionResult CadastroArvore()
        {
            return View();
            // return RedirectToAction("SalvaCadastroArvore");
        }

        public ActionResult CadastroNodo()
        {
            return View("CadastroNodo");
        }

        [HttpGet]
        public ActionResult SalvaCadastroArvore(string materia, string turma)
        {
            var cad_materia = new CadastroMateriaModel.MateriaModel();
            var retorno = cad_materia.Cadastra_Materia(materia: materia, turma: turma);

            return RedirectToAction("Arvores");

        }

        [HttpPost]
        public ActionResult SalvaNodoArvore(string nome, string questao, string respostaA, string respostaB, string respostaC)
        {
            var cad_materia = new CadastroMateriaModel.MateriaModel();
            //TODO Reves os parametros
            var idarvore = _idArvore;
            var retorno = cad_materia.Cadastra_Nodo(arvore: idarvore, nome: nome, questao: questao, respostaA : respostaA, respostaB: respostaB, respostaC: respostaC);

            return RedirectToAction("Nodos","Arvore",new { arvore = idarvore, nome = _nome });

        }

        [HttpGet]
        public ActionResult DeletaMateria(string idMateria)
        {
            var conexao = new CadastroMateriaModel.MateriaModel();

            var retorno = conexao.Deleta_Materia(id: idMateria);

            
            return RedirectToAction("Arvores");
        }

        public ActionResult DeletaNodo(string idNodo, string nome)
        {
            var conexao = new CadastroMateriaModel.MateriaModel();

            var retorno = conexao.Deleta_Nodo(id: idNodo);

            return RedirectToAction("Nodos", "Arvore" , new { Arvore = _idArvore,  nome = nome } );
        }

        public ActionResult ArvoreAluno()
        {
            var retornarSQL = MateriaModel.BuscaListaMateria();

            return View("ArvoreAluno", retornarSQL);
        }

        public ActionResult NodoAluno(string Arvore)
        {
            var retornarSQL = MateriaModel.BuscaListaNodo(arvore: Arvore);
            return View("NodoAluno", retornarSQL);
        }
    }

}