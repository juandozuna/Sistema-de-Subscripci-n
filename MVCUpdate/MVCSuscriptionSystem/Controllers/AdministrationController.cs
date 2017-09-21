using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddRoles(string UserId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.Find(UserId);
                if (user != null)
                {
                    return View(user);
                }
                return HttpNotFound();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoles(FormCollection collection)
        {
            
                AdminManager.AddRolesToUser(collection);
                return View();
            
        }

    }
}