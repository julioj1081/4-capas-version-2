using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntities;
using CapaBusinessLayer;

namespace CapaUI.Controllers
{
    public class HomeController : Controller
    {
        private Usuarios_BL userBL = new Usuarios_BL();
        public ActionResult Index()
        {
            return View(userBL.ListaUsuarios());
        }


        //Genera plantilla Editar
        public Materia_BL materiaBL = new Materia_BL();
        public ActionResult Agregar()
        {
            ViewBag.Materias = materiaBL.Listar();
            return View();
        }
        //Registro
        public ActionResult Registro(Usuarios_ET user)
        {
            userBL.Registrar(user);
            new Usuarios_BL();
            return RedirectToAction("Index");
        }
      

        //Genera plantilla editar con id
        public ActionResult Editar(int id)
        {
            ViewBag.Materias = materiaBL.Listar();
            return View(userBL.Obtener(id));
        }

        //Actualiza
        public ActionResult Actualizar(Usuarios_ET user)
        {
            return RedirectToAction("Index", userBL.Actualizar(user));
        }

        //Vista Eliminar plantilla
        public ActionResult Eliminar(int id)
        {
            ViewBag.Materias = materiaBL.Listar();
            return View(userBL.Obtener(id));
        }


        public ActionResult Eliminar_Usuario(int id)
        {
            return RedirectToAction("Index", userBL.Eliminar(id));
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