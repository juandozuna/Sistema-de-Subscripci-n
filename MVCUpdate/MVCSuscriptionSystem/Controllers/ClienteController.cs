using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var cliente = db.Clientes.Find(id);
            if(cliente != null)
                return View(cliente);
            return HttpNotFound();
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarBorrar(int id)
        {
            var cliente = db.Clientes.Find(id);
            if (cliente != null)
            {
                var subscripcion = cliente.Subscripcion;
                if (subscripcion != null)
                {
                    var plan = cliente.Subscripcion.Plan;
                    if (plan != null) db.Plans.Remove(plan);
                    db.Subscripcions.Remove(subscripcion);
                }
                db.Clientes.Remove(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public override ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(/*FormCollection collection*/Cliente cli, HttpPostedFileBase image1) 
        {
            
            /*Cliente cli = new Cliente()
            {
                Primer_Nombre = collection["Primer_Nombre"],
                Segundo_Nombre = collection["Segundo_Nombre"],
                Primer_Apellido = collection["Primer_Apellido"],
                Numero_Telefonico = collection["Numero_Telefonico"],
                e_mail = collection["e_mail"],
                Metodo_de_Pago = collection["Metodo_de_Pago"],
                NumeroTarjeta = Int32.Parse(collection["NumeroTarjeta"]),
                CVC_o_CVV = Int32.Parse(collection["CVC_o_CVV"])
            };
            cli.Fecha_de_nacimiento = DateTime.ParseExact(collection["Fecha_de_nacimiento"], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);*/
            if (image1 != null)
            {
                cli.ImagenID = ImagenManager.SubirImagen(image1);
            }
            if (cli != null)
            {
                db.Clientes.Add(cli);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public override ActionResult Index()
        {
            var clis = db.Clientes.ToList();
           
            return View(clis);
        }



        public override ActionResult Modificar(int id)
        {
            var cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(FormCollection collection)
        {
            Int32.TryParse(collection["ClientID"], out int id);
            var cliente = db.Clientes.SingleOrDefault(x => x.ClientID == id);
            if (cliente != null)
            {
                cliente.Primer_Nombre = collection["Primer_Nombre"];
                cliente.Segundo_Nombre = collection["Segundo_Nombre"];
                cliente.Primer_Apellido = collection["Primer_Apellido"];
                cliente.Numero_Telefonico = collection["Numero_Telefonico"];
                cliente.e_mail = collection["e_mail"];
                cliente.Metodo_de_Pago = collection["Metodo_de_Pago"];
                cliente.NumeroTarjeta = Int32.Parse(collection["NumeroTarjeta"]);
                cliente.CVC_o_CVV = Int32.Parse(collection["CVC_o_CVV"]);
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
           


        
        public override ActionResult VerDetalles(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente != null)
            {
                ViewBag.ImgSrc = ImagenManager.RetornarSourceImagen(cliente.ImagenID);
                return View(cliente);
            }
            return HttpNotFound();
            
        }
    }
}