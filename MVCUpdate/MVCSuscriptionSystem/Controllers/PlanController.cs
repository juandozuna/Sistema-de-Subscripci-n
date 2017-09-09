using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    [System.Web.Mvc.Authorize]
    public class PlanController : ProgramManager
    {
        [Authorize(Roles = "Admin")]
        public override ActionResult Borrar(int id)
        {
            var plan = db.Plans.Find(id);
            if(plan != null)
                return View(plan);
            return HttpNotFound();

        }


        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Borrar")]
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

        [Authorize(Roles = "Admin")]
        public override ActionResult Crear()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(FormCollection c)
        {
            Plan p = new Plan()
            {
                Nombre = c["Nombre"],
                Precio = Double.Parse(c["Precio"]),
            };
            string[] servicios = c.GetValues("ServicioEnPlans").ToArray();
            if (p != null)
            {
                db.Plans.Add(p);
                db.SaveChanges();
                var pl = db.Plans.OrderByDescending(x => x.PlanID).First();
                foreach (var s in servicios)
                {
                    Int32.TryParse(s, out int servId);
                    if (db.Servicios.Find(servId) != null)
                        db.ServicioEnPlans.Add(new ServicioEnPlan() {PlanID = pl.PlanID, ServicioID = servId});
                    else
                    {
                        return HttpNotFound();
                    }
                }
                db.SaveChanges();
                //PlanManager.AgregarServicios(servicios, pl);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [Authorize]
        public override ActionResult Index()
        {
            var planes = db.Plans.ToList();
            return View(planes);
        }


        [Authorize(Roles = "Admin")]
        public override ActionResult Modificar(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {
                return View(plan);
            }
            return HttpNotFound();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Modificar(FormCollection c)
        {
            var plan = db.Plans.Find(Int32.Parse(c["PlanID"]));
            string[] servicios = c.GetValues("ServicioEnPlans").ToArray();
            if (plan != null)
            {
                foreach (var s in servicios)
                {
                    Int32.TryParse(s, out int servId);
                    if (db.Servicios.Find(servId) != null)
                        db.ServicioEnPlans.Add(new ServicioEnPlan() { PlanID = plan.PlanID, ServicioID = servId });
                    else
                    {
                        return HttpNotFound();
                    }
                };

                plan.Nombre = c["Nombre"];
                plan.Precio = Double.Parse(c["Precio"]);
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

        [Authorize(Roles = "Admin")]
        public ActionResult RemoveService(int ServPlanId, int PlanId)
        {
            var plan = db.Plans.Find(PlanId);
            if (plan != null)
            {
                var servicioEnPlan = db.ServicioEnPlans.Find(ServPlanId);
                if (servicioEnPlan != null)
                {
                    db.Entry(servicioEnPlan).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Modificar",new{id = PlanId});
            }
            return RedirectToAction("Index");
        }
    }
}