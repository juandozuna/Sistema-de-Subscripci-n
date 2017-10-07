using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
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
            db.SaveChanges();

            //este busca los usuarios
            var perfilUsuario = db.PerfilUsuarios.Where(x => x.perfilId == pId).Select(p => p.userId).ToList();

            foreach (var u in perfilUsuario)
            {
                var roles = userManager.GetRoles(u).ToArray();
                userManager.RemoveFromRoles(u, roles);
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

        public static void ModificarPerfil(int pId, string[] roles, string nombrePerfil)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            var perfilUsuario = db.PerfilUsuarios.Where(x => x.perfilId == pId).ToList().AsEnumerable();
            var usersId = perfilUsuario.Select(x => x.userId).ToList();
            var perfil = db.Perfiles.Find(pId);
            perfil.nombrePerfil = nombrePerfil;
            db.Entry(perfil).State = EntityState.Modified;
            if (RemoverRolesDePerfil(pId))
            {
                foreach (var role in roles)
                {
                    var pr = new PerfilRole(){perfilId = pId,roleName = role};
                    db.PerfilRoles.Add(pr);
                }
                db.SaveChanges();

                foreach (var u in usersId)
                {
                    AsociarRolesAUsuario(u, pId);
                }
            } 
        }

        /// <summary>
        /// Este metodo privado asocia a un usuario con los roles que estan dentro de un perfil
        /// </summary>
        /// <param name="userId">ID en string del usuario</param>
        /// <param name="pId">ID del perfil a seleccionar</param>
        public static void AsociarRolesAUsuario(string userId, int pId)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));
            var perfile = db.Perfiles.Find(pId);
            if (perfile != null)
            {
                var roles = perfile.PerfilRoles.Select(x => x.roleName).ToArray();
                if (userManager.FindById(userId) != null)
                {
                    userManager.AddToRoles(userId, roles);
                    

                }
            }
        }

        public static bool CambiarPerfilDeUsuario(string userId, int pId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));

            var roles = userManager.GetRoles(userId).ToArray();

            try
            {
                userManager.RemoveFromRoles(userId,roles);
                AsociarRolesAUsuario(userId, pId);
                return true;
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e + "Uno de las variables no fue encontrada");
                return false;
            }
        }


        public static string[] ArregloDeStringDeRoles(FormCollection c, int skip)
        {
            if (skip > 3) skip = 3;
            else if(skip < 2) skip = 2;
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(adb));
            if (c["Admin"] != null)
            {
                var roles = roleManager.Roles.Select(x => x.Name).ToList();
                roles.Add("Admin");
                return roles.ToArray();
            }
            else
            {
                var roles = c.AllKeys.Skip(skip).ToArray();
                return roles;
            }



        }

        public static Perfile GetPerfile(int pId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(adb));
            var perfile = db.Perfiles.Find(pId);
            return perfile;
        }
    }
}