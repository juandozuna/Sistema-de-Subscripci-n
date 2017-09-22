using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    public class ServiciosAPIController : ApiController
    {
        private EntityModel db = new EntityModel();

        // GET: api/ServiciosAPI
        public IQueryable<Servicio> GetServicios()
        {
            return db.Servicios;
        }

        // GET: api/ServiciosAPI/5
        [ResponseType(typeof(Servicio))]
        public async Task<IHttpActionResult> GetServicio(int id)
        {
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return Ok(servicio);
        }

        // PUT: api/ServiciosAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServicio(int id, Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicio.ServicioID)
            {
                return BadRequest();
            }

            db.Entry(servicio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        // POST: api/ServiciosAPI
        [ResponseType(typeof(Servicio))]
        public async Task<IHttpActionResult> PostServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = servicio.ServicioID }, servicio);
        }

        // DELETE: api/ServiciosAPI/5
        [ResponseType(typeof(Servicio))]
        public async Task<IHttpActionResult> DeleteServicio(int id)
        {
            Servicio servicio = await db.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicio);
            await db.SaveChangesAsync();

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
            return db.Servicios.Count(e => e.ServicioID == id) > 0;
        }
    }
}