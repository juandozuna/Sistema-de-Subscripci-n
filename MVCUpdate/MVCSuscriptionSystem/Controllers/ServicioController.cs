using MVCSuscriptionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize]
    public class ServicioController : ProgramManager
    {
        [Authorize(Roles = "BorrarServicio")]
        public override ActionResult Borrar(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Borrar")]
        [Authorize(Roles = "BorrarServicio")]
        public ActionResult ConfirmarBorrar(int id)
        {
            var servicio = db.Servicios.Find(id);
            if (servicio != null)
            {
                var servplan = db.ServicioEnPlans.Where(x => x.ServicioID == servicio.ServicioID).ToList();
                if (servplan.Any())
                {
                    foreach (var servicioEnPlan in servplan)
                    {
                        db.ServicioEnPlans.Remove(servicioEnPlan);
                    }
                }
                db.Servicios.Remove(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "CrearServicio")]
        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="CrearServicio")]
        public ActionResult Crear(Servicio servicio)
        {
            if (servicio != null)
            {
                db.Servicios.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "VerServicio, ListarServicio")]
        public override ActionResult Index()
        {
            var servicios = db.Servicios;
            return View(servicios.ToList());
        }


        [Authorize(Roles = "ModificarServicio")]
        public override ActionResult Modificar(int id)
        {
            var servicio = db.Servicios.Find(id);
            if (servicio != null)
            {

                return View(servicio);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ModificarServicio")]
        public  ActionResult Modificar(Servicio servicio)
        {
            var s = db.Servicios.Find(servicio.ServicioID);
            if (s != null)
            {
                s.Precio = servicio.Precio;
                s.Nombre = servicio.Nombre;
                s.ImagenID = servicio.ImagenID;
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }


        [Authorize(Roles = "VerServicio, ListarServicio")]
        public override ActionResult VerDetalles(int id)
        {
            var s = db.Servicios.Find(id);
            if (s!=null)
                return View(s);
            return HttpNotFound();
        }
    }
}