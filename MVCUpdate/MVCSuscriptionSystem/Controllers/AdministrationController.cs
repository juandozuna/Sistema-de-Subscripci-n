using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}