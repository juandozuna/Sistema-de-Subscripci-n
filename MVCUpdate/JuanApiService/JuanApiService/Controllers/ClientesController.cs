using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;
using JuanApiService.Models;

namespace JuanApiService.Controllers
{
    /// <summary>
    /// Estos son los metodos del controlador de clientes
    /// </summary>
    public class ClientesController : ApiController
    {
        /// <summary>
        /// Este es el DBset el cual tiene la conexion
        /// a la base de datos a traves de ENTITY
        /// </summary>
        private ApiDatabaseConnection db = new ApiDatabaseConnection();

        // GET: api/Clientes
        /// <summary>
        /// Retorna un arreglo de todos los clientes contenidos en la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        /// <summary>
        /// Retorna el objeto del cliente si es encontrado por el id suministrado
        /// </summary>
        /// <param name="id">Recibe el id del cliente a buscar</param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        /// <summary>
        /// Tomando el id del cliente, recibe al mismo cliente modificado. Por lo que 
        /// este metodo sirve para modificar al cliente
        /// </summary>
        /// <param name="id">Id Del Cliente</param>
        /// <param name="cliente">Objeto del cliente que recibe por JSON</param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = db.Clientes.Find(id);
            if (c != null)
            {
                c.NombreCliente = cliente.NombreCliente;
                c.Ciudad = cliente.Ciudad;
                c.Email = cliente.Email;
                c.Pais = cliente.Pais;
                c.Sector = cliente.Sector;
                c.Telefono = cliente.Telefono;
            }
            
            db.Entry(c).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        /// <summary>
        /// Este metodo crea un cliente nuevo
        /// </summary>
        /// <param name="cliente">Recibe un objeto en JSON de cliente</param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Clientes.Add(cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.ClienteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api/Clientes/5
        /// <summary>
        /// Borra a un cliente de la base de datos
        /// </summary>
        /// <param name="id">Recibe el ID del clientes</param>
        /// <returns></returns>
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteCliente(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }


        /// <summary>
        /// Metodo de Dispose
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

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.ClienteId == id) > 0;
        }
    }
}