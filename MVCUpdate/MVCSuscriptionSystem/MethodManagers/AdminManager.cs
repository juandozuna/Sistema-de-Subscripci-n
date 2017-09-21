using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class AdminManager
    {
        public static void AddRolesToUser(FormCollection collection)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = context.Users.Find(collection["Id"]);
                Dictionary<string, bool> checkboxes = new Dictionary<string, bool>();
                var keys = collection.AllKeys;
                for(int i = 2; i < collection.Count; i++ )
                {
                    string role = keys[i];
                    var result = UserManager.AddToRole(user.Id, role);
                    
                }
            }
        }
    }
}