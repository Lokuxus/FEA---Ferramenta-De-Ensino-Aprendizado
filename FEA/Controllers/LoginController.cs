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

            return View("Login");


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
        public ActionResult Logar(string email, string senha)
        {


            if (ModelState.IsValid)
            {
                return View("../Home/Index");
                //return View("Index", usuario);
            }

            return View("Login");
        }
    }
}