using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEA.Controllers
{
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult ListaArvore()
        {
            return View();
        }

        public ActionResult ListaAluno()
        {
            return View();
        }
    }
}