using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCSuscriptionSystem.Models;
using MVCSuscriptionSystem.Models.ViewModel;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class AdminManager
    {
        public static bool AgregarPerfilAUsuario(FormCollection collection)
        {
            var uId = collection["Id"];
            var p = collection["perfileSelection"];
            if (Int32.TryParse(p, out int pId))
            {
                PerfilManager.AsociarRolesAUsuario(uId, pId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static IEnumerable<UsuarioListado> UsuariosConPerfiles()
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
            });
            return usuarios;
        }
    }

}