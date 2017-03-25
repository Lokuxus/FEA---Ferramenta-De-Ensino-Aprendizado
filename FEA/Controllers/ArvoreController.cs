using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEA.Controllers
{
    public class ArvoreController : Controller
    {
        // GET: Lista
        public ActionResult Arvores()
        {
            return View();
        }

        public ActionResult CadastroArvore()
        {
            return View();
        }

    }
}