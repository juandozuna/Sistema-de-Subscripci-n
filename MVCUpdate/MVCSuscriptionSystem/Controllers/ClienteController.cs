using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    public class ClienteController : ProgramManager
    {
        public override ActionResult Borrar(int id)
        {
            return View();
        }

        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(FormCollection collection, HttpPostedFileBase image1) 
        {
            if(image1 != null) ImagenManager.SubirImagen(image1);
            Cliente cli = new Cliente()
            {
                Primer_Nombre = collection["Primer_Nombre"],
                Segundo_Nombre = collection["Segundo_Nombre"],
                Primer_Apellido = collection["Primer_Apellido"],
                ImagenID = ImagenManager.IdImagenSubida(),
                Fecha_de_nacimiento = DateTime.Parse(collection["Fecha_de_nacimiento"]),
                Fecha_de_expiracion = DateTime.Parse(collection["Fecha_de_expiracion"]),
                Numero_Telefonico = collection["Numero_Telefonico"],
                e_mail = collection["e_mail"],
                Metodo_de_Pago = collection["Metodo_de_Pago"],
                NumeroTarjeta = Int32.Parse(collection["NumeroTarjeta"]),
                CVC_o_CVV = Int32.Parse(collection["CVC_o_CVV"])
            };
            Db.Clientes.Add(cli);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public override ActionResult Index()
        {
            return View();
        }



        public override ActionResult Modificar(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(FormCollection collection)
        {
           
            return RedirectToAction("Index","Home");
        }



        public override ActionResult VerDetalles(int id)
        {
            return View();
        }
    }
}