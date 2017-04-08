using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FEA.CadastroMateriaModel;

namespace FEA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var retornarSQL = MateriaModel.NumeroMateria();

            return View("Index", retornarSQL);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}