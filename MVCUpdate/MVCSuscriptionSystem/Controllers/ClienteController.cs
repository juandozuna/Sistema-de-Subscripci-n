using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    public class ClienteController : ProgramManager
    {
        public override ActionResult Borrar(int id)
        {
            return View();
        }

        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Crear(FormCollection collection)
        {
            
            return RedirectToAction("Index");
        }

        public override ActionResult Index()
        {
            return View();
        }



        public override ActionResult Modificar(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Modificar(FormCollection collection)
        {
            return RedirectToAction("Index");
        }



        public override ActionResult VerDetalles(int id)
        {
            return View();
        }
    }
}