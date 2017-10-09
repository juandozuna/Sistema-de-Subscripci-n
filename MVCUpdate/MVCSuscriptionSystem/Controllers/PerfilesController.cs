using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;
using Newtonsoft.Json;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PerfilesController : ProgramManager
    {
        public override ActionResult Borrar(int id)
        {
            var perfil = db.Perfiles.Find(id);
            if (perfil != null)
            {
                PerfilManager.BorrarPerfil(perfil.PerfilID);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(FormCollection c)
        {
            var roles = PerfilManager.ArregloDeStringDeRoles(c, 2);
            var nombre = c["nombrePerfil"];
            if (nombre != null || nombre == "") RedirectToAction("Crear");
            PerfilManager.CrearPerfil(nombre, roles);

            return RedirectToAction("Index");
        }



        // GET: Perfiles
        public override ActionResult Index()
        {
            var perfiles = db.Perfiles.ToList();
            return View(perfiles);
        }

        public override ActionResult Modificar(int id)
        {
            ViewBag.PerfilId = id;
            var perfil = db.Perfiles.Find(id);
            if(perfil != null)
            return View(perfil);
            else
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult Modificar(FormCollection c)
        {
            var roles = PerfilManager.ArregloDeStringDeRoles(c,3);
            var nombre = c["nombrePerfil"];
            var stringId = c["PerfilID"];

            if (Int32.TryParse(stringId, out int id))
            {
                var perfil = db.Perfiles.Find(id);
                if (perfil != null)
                {
                    PerfilManager.ModificarPerfil(id, roles, nombre);
                }
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }


        public override ActionResult VerDetalles(int id)
        {
            var perfil = db.Perfiles.Find(id);
            if (perfil != null)
            { return View(perfil);}
            else
            {
                return HttpNotFound();
            }
        }


        /// <summary>
        /// Este metodo retorna JSON para ser utilizado en una de las ventanas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetPerfilDetalles(int id)
        {
            var perfil = PerfilManager.GetPerfile(id);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };

            Formatting format = Formatting.Indented;
            var serializer = JsonSerializer.Create(settings);
            var json = JsonConvert.SerializeObject(perfil, format);


            if (perfil != null)
            {
                return Content(json, "application/json", Encoding.UTF8);
            }
            return new EmptyResult();
        }


       
    }
}
