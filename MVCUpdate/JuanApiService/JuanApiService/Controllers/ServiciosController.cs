using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using JuanApiService.Models;

namespace JuanApiService.Controllers
{
    public class ServiciosController : ApiController
    {
        private ApiDatabaseConnection db = new ApiDatabaseConnection();

        // GET: api/Servicios
        //<summary>
        //Retorna arreglos de todo los servicios en la base de datos
        //</summary>
        public IQueryable<Servicio> GetServicios()
        {
            return db.Servicios;
        }

        // GET: api/Servicios/5
        [ResponseType(typeof(Servicio))]
        public IHttpActionResult GetServicio(int id)
        {
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return Ok(servicio);
        }

        //get: / /api/Servicios/5?sId=1
        [ResponseType(typeof(SuscripcionServicio))]
        [HttpPost]
        public IHttpActionResult ServiceToSuscription(int id, int sId)
        {
            var servi = db.Servicios.Find(id);
            if (servi != null)
            {
                var suscrip = db.Suscripciones.Find(sId);
                if (suscrip != null)
                {
                    var serviSuscri = new SuscripcionServicio()
                    {
                        ServicioId = servi.ServicioId,
                        SuscripcionId = suscrip.SuscripcionId
                    };
                    db.SuscripcionServicios.Add(serviSuscri);
                    db.SaveChanges();
                    return Ok(serviSuscri);
                }
            }
            return NotFound();
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicio(int id, Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicio.ServicioId)
            {
                return BadRequest();
            }

            db.Entry(servicio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Servicios
        [ResponseType(typeof(Servicio))]
        public IHttpActionResult PostServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ServicioExists(servicio.ServicioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = servicio.ServicioId }, servicio);
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicio))]
        public IHttpActionResult DeleteServicio(int id)
        {
            Servicio servicio = db.Servicios.Find(id);
            if (servicio == null)
            {
                return NotFound();
            }
            foreach (var a in db.Suscripciones)
            {
                var b = a.SuscripcionServicios.Where(x => x.ServicioId == servicio.ServicioId).ToList();
                db.SuscripcionServicios.RemoveRange(b);
            }
            db.Servicios.Remove(servicio);
            db.SaveChanges();

            return Ok(servicio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicioExists(int id)
        {
            return db.Servicios.Count(e => e.ServicioId == id) > 0;
        }
    }
}