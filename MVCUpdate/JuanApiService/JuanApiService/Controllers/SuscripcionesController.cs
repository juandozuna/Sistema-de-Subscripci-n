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
    /// <summary>
    /// Controlador de suscripciones
    /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
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
        /// <summary>
        /// Este metodo sirve para modificar una suscripcion ya existente
        /// </summary>
        /// <param name="id">Este es el ID de la suscripcion a modificar</param>
        /// <param name="suscripcione">Recibe un objeto por PUT con los parametros a modificar de dicha suscripcion</param>
        /// <returns>Retorna void</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuscripcione(int id, Suscripcione suscripcione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var s = db.Suscripciones.Find(id);
            if (s != null)
            {
                s.Activo = suscripcione.Activo;
                s.FechaDeCreacion = suscripcione.FechaDeCreacion;
                s.ClienteId = suscripcione.ClienteId;
                s.SuscriptorId = suscripcione.SuscriptorId;
                db.Entry(suscripcione).State = EntityState.Modified;
            }
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

        // DELETE: api/Suscripciones/5
      /// <summary>
      /// Este metodo borra una suscripcion ya existente
      /// </summary>
      /// <param name="id">Recibe el id de la suscripcion a borrar</param>
      /// <returns>Retorna la informacion contenida en la suscripcion borrada</returns>
        [ResponseType(typeof(Suscripcione))]
        public IHttpActionResult DeleteSuscripcione(int id)
        {
            Suscripcione suscripcione = db.Suscripciones.Find(id);
            if (suscripcione == null)
            {
                return NotFound();
            }
            var ser = suscripcione.SuscripcionServicios.ToList();
            db.SuscripcionServicios.RemoveRange(ser);
            db.Suscripciones.Remove(suscripcione);
            db.SaveChanges();

            return Ok(suscripcione);
        }

        //POST: api/Suscripciones/1/0
        /// <summary>
        /// Esta funcion modifica el estado de una suscripcion, Si esta activa o desactivada
        /// </summary>
        /// <param name="id">Recibe el id de la suscripcion a activar o desactivar</param>
        /// <param name="status">Recibe 1 para activar una suscripcion o 0 para desactivar la suscripcion</param>
        /// <returns></returns>
        [ResponseType(typeof(Suscripcione))]
        [HttpPost]
        public IHttpActionResult EstadoSuscripcion(int id, int status)
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

        /// <summary>
        /// Disposable
        /// </summary>
        /// <param name="disposing"></param>
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