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
using Microsoft.Ajax.Utilities;

namespace JuanApiService.Controllers
{
    public class SuscriptorsController : ApiController
    {
        private ApiDatabaseConnection db = new ApiDatabaseConnection();

        // GET: api/Suscriptors
        public IQueryable<Suscriptor> GetSuscriptors()
        {
            return db.Suscriptors;
        }

        // GET: api/Suscriptors/5
        [ResponseType(typeof(Suscriptor))]
        public IHttpActionResult GetSuscriptor(int id)
        {
            Suscriptor suscriptor = db.Suscriptors.Find(id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            return Ok(suscriptor);
        }

        // PUT: api/Suscriptors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuscriptor(int id, Suscriptor suscriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suscriptor.SuscriptorId)
            {
                return BadRequest();
            }

            db.Entry(suscriptor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuscriptorExists(id))
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

        // POST: api/Suscriptors
        [ResponseType(typeof(Suscriptor))]
        public IHttpActionResult PostSuscriptor(Suscriptor suscriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (suscriptor.ClienteId != 0)
            {
                var suscripcion = new Suscripcione()
                {
                    ClienteId = suscriptor.ClienteId,
                    SuscriptorId = suscriptor.SuscriptorId,
                    Activo = false,
                    FechaDeCreacion = DateTime.Today
                };
                db.Suscripciones.Add(suscripcion);
            }
            db.Suscriptors.Add(suscriptor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SuscriptorExists(suscriptor.SuscriptorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = suscriptor.SuscriptorId }, suscriptor);
        }

        // DELETE: api/Suscriptors/5
        [ResponseType(typeof(Suscriptor))]
        public IHttpActionResult DeleteSuscriptor(int id)
        {
            Suscriptor suscriptor = db.Suscriptors.Find(id);
            if (suscriptor == null)
            {
                return NotFound();
            }

            db.Suscriptors.Remove(suscriptor);
            db.SaveChanges();

            return Ok(suscriptor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuscriptorExists(int id)
        {
            return db.Suscriptors.Count(e => e.SuscriptorId == id) > 0;
        }
    }
}