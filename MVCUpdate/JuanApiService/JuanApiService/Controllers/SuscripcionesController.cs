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
    public class SuscripcionesController : ApiController
    {
        private ApiDatabaseConnection db = new ApiDatabaseConnection();

        // GET: api/Suscripciones
        ///<summary>
        ///Retorna lista de suscripciones en base de datos
        ///</summary>
        /// <returns></returns>
        public IQueryable<Suscripcione> GetSuscripciones()
        {
            return db.Suscripciones;
        }

        // GET: api/Suscripciones/5
        ///<summary>
        ///Busca una suscripcion en especifico y la retorna
        ///<summary>
        /// <returns></returns>
        [ResponseType(typeof(Suscripcione))]
        public IHttpActionResult GetSuscripcione(int id)
        {
            Suscripcione suscripcione = db.Suscripciones.Find(id);
            if (suscripcione == null)
            {
                return NotFound();
            }

            return Ok(suscripcione);
        }

        // PUT: api/Suscripciones/5
        ///<summary>
        ///Busca una suscripcion y la modifica
        ///</summary>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuscripcione(int id, Suscripcione suscripcione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suscripcione.SuscripcionId)
            {
                return BadRequest();
            }

            db.Entry(suscripcione).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuscripcioneExists(id))
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

        // POST: api/Suscripciones
        ///<summary>
        ///Crea una suscripcion nueva
        ///</summary>
        /// <returns></returns>
        [ResponseType(typeof(Suscripcione))]
        public IHttpActionResult PostSuscripcione(Suscripcione suscripcione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suscripciones.Add(suscripcione);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SuscripcioneExists(suscripcione.SuscripcionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = suscripcione.SuscripcionId }, suscripcione);
        }

        // DELETE: api/Suscripciones/5
        ///<summary>
        ///Borra una suscripcion existente de ID tal
        ///</summary>
        /// <returns></returns>
        [ResponseType(typeof(Suscripcione))]
        public IHttpActionResult DeleteSuscripcione(int id)
        {
            Suscripcione suscripcione = db.Suscripciones.Find(id);
            if (suscripcione == null)
            {
                return NotFound();
            }

            db.Suscripciones.Remove(suscripcione);
            db.SaveChanges();

            return Ok(suscripcione);
        }

        //POST: api/Suscripciones/1/0
        ///<summary>
        ///Modifica el estado de una suscripcion si activa o no
        ///</summary>
        /// <returns></returns>
        [ResponseType(typeof(Suscripcione))]
        public IHttpActionResult GetSuscripcione(int id, int status)
        {
            bool estado;
            if (status == 1) estado = true;
            else estado = false;
            var suscripcion = db.Suscripciones.Find(id);
            if (suscripcion != null)
            {
                suscripcion.Activo = estado;
                db.Entry(suscripcion).State = EntityState.Modified;
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SuscripcioneExists(suscripcion.SuscripcionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(suscripcion);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuscripcioneExists(int id)
        {
            return db.Suscripciones.Count(e => e.SuscripcionId == id) > 0;
        }
    }
}