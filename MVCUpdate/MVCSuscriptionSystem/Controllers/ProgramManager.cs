using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    public abstract class ProgramManager : Controller
    {
        //public EntityModel db = new EntityModel();
        public MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
        public abstract ActionResult Index(); 
        //La pagina index varia dependendiendo 
        //del rol del usuario y la funcion que este utilize.
        public abstract ActionResult Modificar(int id);

        public abstract ActionResult VerDetalles(int id);

        public abstract ActionResult Borrar(int id);


        public abstract ActionResult Crear();



    }
}