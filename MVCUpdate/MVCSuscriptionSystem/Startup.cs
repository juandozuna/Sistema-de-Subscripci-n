using System.Linq;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSuscriptionSystem.Startup))]
namespace MVCSuscriptionSystem
{
    public partial class Startup
    {
        public async void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            await CreateRolesandUsersAsync();
        }

        private async Task CreateRolesandUsersAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //await userManager.DeleteAsync(userManager.FindById("9d7c4abb-e180-423a-9ec2-9c91f8e6ec90"));
            // In Startup iam creating first Admin Role and creating a default Admin User    
            //PerfilManager.DeleteProfileFromDb(5);
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

            var roles = roleManager.Roles.Select(r => r.Name).ToArray();
            var user = userManager.FindByName("admin");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                string userPWD = "Intec.123";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    
                    var result = await userManager.AddToRolesAsync(user.Id, roles);

                }
            }
        }


    }
    
}



//var result1 = userManager.AddToRole(user.Id, "Admin");
//result1 = userManager.AddToRole(user.Id, "CrearCliente");
//result1 = userManager.AddToRole(user.Id, "ListarCliente");
//result1 = userManager.AddToRole(user.Id, "VerCliente");
//result1 = userManager.AddToRole(user.Id, "ModificarCliente");
//result1 = userManager.AddToRole(user.Id, "BorrarCliente");
//result1 = userManager.AddToRole(user.Id, "CrearPlan");
//result1 = userManager.AddToRole(user.Id, "ListarPlan");
//result1 = userManager.AddToRole(user.Id, "VerPlan");
//result1 = userManager.AddToRole(user.Id, "ModificarPlan");
//result1 = userManager.AddToRole(user.Id, "BorrarPlan");
//result1 = userManager.AddToRole(user.Id, "CrearServicio");
//result1 = userManager.AddToRole(user.Id, "ListarServicio");
//result1 = userManager.AddToRole(user.Id, "VerServicio");
//result1 = userManager.AddToRole(user.Id, "ModificarServicio");
//result1 = userManager.AddToRole(user.Id, "BorrarServicio");
//result1 = userManager.AddToRole(user.Id, "CrearSuscripcion");
//result1 = userManager.AddToRole(user.Id, "ListarSuscripcion");
//result1 = userManager.AddToRole(user.Id, "VerSuscripcion");
//result1 = userManager.AddToRole(user.Id, "ModificarSuscripcion");
//result1 = userManager.AddToRole(user.Id, "BorrarSuscripcion");