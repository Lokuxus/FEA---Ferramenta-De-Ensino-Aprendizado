using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FEA.Usuario;

using System.Data.SqlClient;
using FEA.Models;

namespace FEA.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {
            var usuario = new UsuarioViewModel();
            return View("Login", usuario);

//            if(usuario.IsLogado(user: "hendrig", psswd: "teste"))
  //          {   
    //            ViewBag.Login = usuario.Login;
     //          return RedirectToAction("Login");
        //    }else
          //  {
            //    return RedirectToAction("Erro");
           // }

            
        }

        [HttpPost]
        public ActionResult Logar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                return View("../Home/Index", usuario);
                //return View("Index", usuario);
            }

            return View("Login", usuario);
        }

        private ActionResult Resultado(UsuarioViewModel usuario)
        {
            return View(usuario);
        }

    }
}