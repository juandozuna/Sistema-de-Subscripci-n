using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCSuscriptionSystem.Controllers
{
    public class SubscripcionsController : Controller
    {
        private EntityModel db = new EntityModel();

        // GET: Subscripcions
        [Authorize(Roles = "VerSuscripcion, ListarSuscripcion")]
        public ActionResult Index()
        {
            var cliente = new HttpClient();
            var respuesta = cliente.GetAsync("http://localhost:55040/api/SubscripcionsAPI").Result;
            var suscripciones = respuesta.Content.ReadAsAsync<IEnumerable<Subscripcion>>().Result;
            return View(suscripciones.ToList());
        }

        // GET: Subscripcions/Details/5
        [Authorize(Roles = "VerSuscripcion, ListarSuscripcion")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscripcion subscripcion = db.Subscripcions.Find(id);
            if (subscripcion == null)
            {
                return HttpNotFound();
            }
            return View(subscripcion);
        }

        // GET: Subscripcions/Create
        //Cambiar Authorize por condicion para revisar el rol del usuario
        //[Authorize]
        [Authorize(Roles = "CrearSuscripcion")]
        public ActionResult Create()
        {
            ViewBag.ImageID = new SelectList(db.Images, "imagesID", "Nombre");
            ViewBag.PlanID = new SelectList(db.Plans, "PlanID", "Nombre");
            return View();
        }

        // POST: Subscripcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CrearSuscripcion")]
        public ActionResult Create([Bind(Include = "SubscripcionID,ClientID,PlanID,Fecha_creacion,Active,ImageID")] Subscripcion subscripcion)
        {
            using (var cliente = new HttpClient())
            {
                var postTask = cliente.PostAsJsonAsync("http://localhost:55040/api/SubscripcionsAPI", subscripcion);
                postTask.Wait();

                var resultado = postTask.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Error!!");
            return View(subscripcion);
            //CONTINUAR AQUI
            //if (ModelState.IsValid)
            //{
            //    db.Subscripcions.Add(subscripcion);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}


            //ViewBag.ImageID = new SelectList(db.Images, "imagesID", "Nombre", subscripcion.ImageID);
            //ViewBag.PlanID = new SelectList(db.Plans, "PlanID", "Nombre", subscripcion.PlanID);
            //return View(subscripcion);
        }

        // GET: Subscripcions/Edit/5
        [Authorize(Roles = "ModificarSuscripcion")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscripcion subscripcion = db.Subscripcions.Find(id);
            if (subscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageID = new SelectList(db.Images, "imagesID", "Nombre", subscripcion.ImageID);
            ViewBag.PlanID = new SelectList(db.Plans, "PlanID", "Nombre", subscripcion.PlanID);
            return View(subscripcion);
        }

        // POST: Subscripcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ModificarSuscripcion")]
        public ActionResult Edit([Bind(Include = "SubscripcionID,ClientID,PlanID,Fecha_creacion,Active,ImageID")] Subscripcion subscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImageID = new SelectList(db.Images, "imagesID", "Nombre", subscripcion.ImageID);
            ViewBag.PlanID = new SelectList(db.Plans, "PlanID", "Nombre", subscripcion.PlanID);
            return View(subscripcion);
        }

        // GET: Subscripcions/Delete/5
        [Authorize(Roles = "BorrarSuscripcion")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscripcion subscripcion = db.Subscripcions.Find(id);
            if (subscripcion == null)
            {
                return HttpNotFound();
            }
            return View(subscripcion);
        }

        // POST: Subscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BorrarSuscripcion")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscripcion subscripcion = db.Subscripcions.Find(id);
            db.Subscripcions.Remove(subscripcion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
