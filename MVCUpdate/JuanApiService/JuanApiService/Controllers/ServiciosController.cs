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
using JuanApiService.Models;

namespace JuanApiService.Controllers
{
    public class ServiciosController : ApiController
    {
        private ApiDatabaseConnection db = new ApiDatabaseConnection();

        // GET: api/Servicios
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