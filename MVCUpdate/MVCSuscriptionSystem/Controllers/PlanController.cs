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
        [Authorize(Roles = "BorrarPlan")]
        public override ActionResult Borrar(int id)
        {
            var plan = db.Plans.Find(id);
            if(plan != null)
                return View(plan);
            return HttpNotFound();

        }


        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Borrar")]
        [Authorize(Roles = "BorrarPlan")]
        public ActionResult ConfirmarBorrar(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {
                var servplan = db.ServicioEnPlans.Where(x => x.PlanID == plan.PlanID).ToList();
                var suscripciones = db.Subscripcions.Where(s => s.PlanID == id);
                if (suscripciones.Any()) db.Subscripcions.RemoveRange(suscripciones);
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

        [Authorize(Roles = "CrearPlan")]
        public override ActionResult Crear()
        {
            if (db.Servicios.Count() <= 0)
            {
                ViewBag.Error = "No puede crear un plan si no hay servicios";
                return View("Error");
            }
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CrearPlan")]
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
               
            }
            var suma = p.ServicioEnPlans.Sum(r => r.Servicio.Precio);
            if (suma > p.Precio)
            {
                ViewBag.Error = "No puede crear un plan menor que el costo total de los servicios." +
                                "Hemos actualizado el precio del plan a " + suma +
                                ". Puede modificar el valor si desea. ";
                p.Precio = suma;
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }

        [Authorize]
        [Authorize(Roles = "VerPlan, ListarPlan")]
        public override ActionResult Index()
        {
            var planes = db.Plans.ToList();
            return View(planes);
        }


        [Authorize(Roles = "ModificarPlan")]
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
        [Authorize(Roles = "ModificarPlan")]
        public  ActionResult Modificar(FormCollection c)
        {
            var plan = db.Plans.Find(Int32.Parse(c["PlanID"]));
            var servicios = c.GetValues("ServicioEnPlans").ToList();
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

                var suma = plan.ServicioEnPlans.Sum(r => r.Servicio.Precio);
                if (suma > plan.Precio)
                {
                    ViewBag.Error = "No puede crear un plan menor que el costo total de los servicios." +
                                    "Hemos actualizado el precio del plan a " + suma +
                                    ". Puede modificar el valor si desea. ";
                    plan.Precio = suma;
                    db.Entry(plan).State = EntityState.Modified;
                    db.SaveChanges();
                    return View("Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }


        [Authorize(Roles = "VerPlan, ListarPlan")]
        public override ActionResult VerDetalles(int id)
        {
            var plan = db.Plans.Find(id);
            if (plan != null)
            {

                return View(plan);
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "ModificarPlan")]
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