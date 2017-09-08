using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    public class PlanController : ProgramManager
    {
        public override ActionResult Borrar(int id)
        {
            var plan = db.Plans.Find(id);
            if(plan != null)
                return View(plan);
            return HttpNotFound();

        }


        [HttpPost, ActionName("Borrar")]
        public ActionResult ConfirmarBorrar(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {
                var servplan = db.ServicioEnPlans.Where(x => x.PlanID == plan.PlanID).ToList();
                if (servplan.Any())
                {
                    foreach (var servicioEnPlan in servplan)
                    {
                        db.ServicioEnPlans.Remove(servicioEnPlan);
                    }
                }
                db.Plans.Remove(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Plan p)
        {
            if (p != null)
            {
                db.Plans.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public override ActionResult Index()
        {
            var planes = db.Plans.ToList();
            return View(planes);
        }



        public override ActionResult Modificar(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {
                return View(plan);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Modificar(Plan p)
        {
            var plan = db.Plans.Find(p.PlanID);
            if (plan != null)
            {
                plan.ImagenID = p.ImagenID;
                plan.Nombre = p.Nombre;
                plan.Precio = p.Precio;
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }



        public override ActionResult VerDetalles(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {

                return View(plan);
            }
            return HttpNotFound();
        }
    }
}