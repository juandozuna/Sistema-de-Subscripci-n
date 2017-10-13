using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.Models.ViewModel;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
       private ApplicationDbContext adb = new ApplicationDbContext();
       private MVCSuscriptionDatabseEntities1 db = new MVCSuscriptionDatabseEntities1();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddRoles(string UserId)
        {
            
                var user = adb.Users.Find(UserId);
                if (user != null)
                {
                    return View(user);
                }
                return HttpNotFound();
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoles(FormCollection collection)
        {
            
                AdminManager.AgregarPerfilAUsuario(collection);
                return View("Index");
            
        }


        public ActionResult Listado()
        {

            MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
            ApplicationDbContext adb = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            var users = userManager.Users.ToList().Except(userManager.Users.Where(x => x.UserName == "admin"));
            var perfiles = db.PerfilUsuarios.ToList();
            var usuarios = users.Join(perfiles, u => u.Id, p => p.userId, (u, p) => new UsuarioListado()
            {
                CorreoElectronico = u.Email,
                Id = u.Id,
                NombreDeUsuario = u.UserName,
                perfile = p.Perfile,
                IdPerfilUsuario = p.perfilUserId
            }).ToList();



            return View(usuarios);
        }

        public ActionResult BorrarUsuario(string id)
        {
            var usuario = AdminManager.UsuariosConPerfiles().SingleOrDefault(p => p.Id == id);
            
            return View(usuario);
        }

        [HttpPost, ActionName("BorrarUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmBorrarUsuario(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));
            var usuario = userManager.FindById(id);
            if (usuario != null)
            {
                userManager.Delete(usuario);
                return RedirectToAction("Listado");
            }
            return HttpNotFound();

        }


        public ActionResult Modificar(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));
            var user = userManager.FindById(id);
            if (user != null)
                return View(user);
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(FormCollection c)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));
            var id = c["Id"];
            var user = userManager.FindById(id);
            if (user == null) return HttpNotFound();

            string perfileSelectionCollection = c["perfileSelection"];
            Int32.TryParse(perfileSelectionCollection, out int pId);

            PerfilManager.CambiarPerfilDeUsuario(id, pId);
            
            return RedirectToAction("Index");
        }


    }
}