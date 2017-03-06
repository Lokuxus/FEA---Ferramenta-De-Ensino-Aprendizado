using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FEA.Models;

namespace FEA.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            var usuario = new UsuarioViewModel();
            return View("Login", usuario);
        }

        [HttpPost]
        public ActionResult Logar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                return View("Resultado", usuario);
            }

            return View("Login", usuario);
        }

        private ActionResult Resultado(UsuarioViewModel usuario)
        {
            return View(usuario);
        }

    }
}