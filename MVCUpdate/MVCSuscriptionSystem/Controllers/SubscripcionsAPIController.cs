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
    public class SubscripcionsAPIController : ApiController
    {
        private EntityModel db = new EntityModel();

        // GET: api/SubscripcionsAPI
        public IQueryable<Subscripcion> GetSubscripcions()
        {
            return db.Subscripcions;
        }

        

        // GET: api/SubscripcionsAPI/5
        [ResponseType(typeof(Subscripcion))]
        public async Task<IHttpActionResult> GetSubscripcion(int id)
        {
            Subscripcion subscripcion = await db.Subscripcions.FindAsync(id);
            if (subscripcion == null)
            {
                return NotFound();
            }

            return Ok(subscripcion);
        }

        // PUT: api/SubscripcionsAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscripcion(int id, Subscripcion subscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscripcion.SubscripcionID)
            {
                return BadRequest();
            }

            db.Entry(subscripcion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscripcionExists(id))
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

        // POST: api/SubscripcionsAPI
        [ResponseType(typeof(Subscripcion))]
        public async Task<IHttpActionResult> PostSubscripcion(Subscripcion subscripcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscripcions.Add(subscripcion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subscripcion.SubscripcionID }, subscripcion);
        }

        // DELETE: api/SubscripcionsAPI/5
        [ResponseType(typeof(Subscripcion))]
        public async Task<IHttpActionResult> DeleteSubscripcion(int id)
        {
            Subscripcion subscripcion = await db.Subscripcions.FindAsync(id);
            if (subscripcion == null)
            {
                return NotFound();
            }

            db.Subscripcions.Remove(subscripcion);
            await db.SaveChangesAsync();

            return Ok(subscripcion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscripcionExists(int id)
        {
            return db.Subscripcions.Count(e => e.SubscripcionID == id) > 0;
        }
    }
}