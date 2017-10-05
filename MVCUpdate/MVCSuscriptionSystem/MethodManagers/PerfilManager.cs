using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class PerfilManager
    {
        private static MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
        private static ApplicationDbContext adb = new ApplicationDbContext();


        public static void CrearPerfil(string name, string[] roles)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            var perfil = new Perfile(){nombrePerfil = name};
            db.Perfiles.Add(perfil);
            db.SaveChanges();

            var prList = new List<PerfilRole>();
            foreach (var item in roles)
            {
                if (roleManager.FindByName(item) != null)
                {
                    prList.Add(new PerfilRole() {perfilId = perfil.PerfilID, roleName = item});
                    
                }

            }
            if (prList.Count > 0) db.PerfilRoles.AddRange(prList);
            db.SaveChanges();
        }

        private static bool RemoverRolesDePerfil(int pId)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            //Remueve los roles de la base de datos personal
            var perfiRoles = db.PerfilRoles.Where(r => r.perfilId == pId).ToList();
            db.PerfilRoles.RemoveRange(perfiRoles);

            //este busca los usuarios
            var perfilUsuario = db.PerfilUsuarios.Where(x => x.perfilId == pId).ToList();
            var users = adb.Roles.Where(x => perfilUsuario.All(p => p.userId == x.Id)).ToList();

            foreach (var u in users)
            {
                var roles = userManager.GetRoles(u.Id).ToArray();
                userManager.RemoveFromRoles(u.Id, roles);
            }

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbException)
            {
                return false;
            }

        }

        public static void ModificarPerfil(int pId, string roles)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            
             
        }

    }
}