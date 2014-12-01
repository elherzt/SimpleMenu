using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Menu;
using Menu.Models;
using Models;
using System.Text;

namespace Menu.Controllers
{
    public class HomeController : Controller
    {
        MenuContext db = new MenuContext();

        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public JsonResult Menu()
        {
            return Json(Arbol.getActualMenu(), "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MenuAdmin()
        {
            Arbol a = new Arbol();
            return Json(a.getMenuByRol(1), "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MenuUser()
        {
            Arbol a = new Arbol();
            return Json(a.getMenuByRol(2), "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MenuInvitado()
        {
            Arbol a = new Arbol();
            return Json(a.getMenuByRol(3), "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Página de descripción de la aplicación.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Página de contacto.";

        //    return View();
        //}
    }
}
