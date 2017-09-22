using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MVCSuscriptionSystem.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSuscriptionSystem.Startup))]
namespace MVCSuscriptionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

            
            }

            // creating Creating Manager role  
            string SRol = "CrearCliente";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ListarCliente";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "VerCliente";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ModificarCliente";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "BorrarCliente";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "CrearPlan";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ListarPlan";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "VerPlan";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ModificarPlan";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "BorrarPlan";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "CrearServicio";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ListarServicio";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "VerServicio";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ModificarServicio";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "BorrarServicio";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "CrearSuscripcion";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ListarSuscripcion";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "VerSuscripcion";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "ModificarSuscripcion";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }

            SRol = "BorrarSuscripcion";
            if (!roleManager.RoleExists(SRol))
            {
                var role = new IdentityRole();
                role.Name = SRol;
                roleManager.Create(role);

            }
            var user = context.Users.Where(x => x.UserName == "admin").First();
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "Intec.123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                    result1 = UserManager.AddToRole(user.Id, "CrearCliente");
                    result1 = UserManager.AddToRole(user.Id, "ListarCliente");
                    result1 = UserManager.AddToRole(user.Id, "VerCliente");
                    result1 = UserManager.AddToRole(user.Id, "ModificarCliente");
                    result1 = UserManager.AddToRole(user.Id, "BorrarCliente");
                    result1 = UserManager.AddToRole(user.Id, "CrearPlan");
                    result1 = UserManager.AddToRole(user.Id, "ListarPlan");
                    result1 = UserManager.AddToRole(user.Id, "VerPlan");
                    result1 = UserManager.AddToRole(user.Id, "ModificarPlan");
                    result1 = UserManager.AddToRole(user.Id, "BorrarPlan");
                    result1 = UserManager.AddToRole(user.Id, "CrearServicio");
                    result1 = UserManager.AddToRole(user.Id, "ListarServicio");
                    result1 = UserManager.AddToRole(user.Id, "VerServicio");
                    result1 = UserManager.AddToRole(user.Id, "ModificarServicio");
                    result1 = UserManager.AddToRole(user.Id, "BorrarServicio");
                    result1 = UserManager.AddToRole(user.Id, "CrearSuscripcion");
                    result1 = UserManager.AddToRole(user.Id, "ListarSuscripcion");
                    result1 = UserManager.AddToRole(user.Id, "VerSuscripcion");
                    result1 = UserManager.AddToRole(user.Id, "ModificarSuscripcion");
                    result1 = UserManager.AddToRole(user.Id, "BorrarSuscripcion");

                }
            }
        }


    }
    
}
