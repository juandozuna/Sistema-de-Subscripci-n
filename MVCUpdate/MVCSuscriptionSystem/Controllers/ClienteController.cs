using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.Web;
using MVCSuscriptionSystem.MethodManagers;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize]
    public class ClienteController : ProgramManager
    {
        [Authorize(Roles = "BorrarCliente")]
        public override ActionResult Borrar(int id)
        {
            var cliente = db.Clientes.Find(id);
            if(cliente != null)
                return View(cliente);
            return HttpNotFound();
        }

        [HttpPost, ActionName("Borrar")]
        [Authorize(Roles="BorrarCliente")]
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

        [Authorize(Roles = "CrearCliente")]
        public override ActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CrearCliente")]
        public ActionResult Crear(Cliente cli, HttpPostedFileBase image1) 
        {

            var emailExiste = db.Clientes.FirstOrDefault(b => b.e_mail.ToLower() == cli.e_mail.ToLower());
            if (emailExiste == null)
            {
                if (image1 != null)
                {
                    cli.ImagenID = ImagenManager.SubirImagen(image1);
                }
                if (cli != null)
                {
                    db.Clientes.Add(cli);
                    db.SaveChanges();
                    cli = db.Clientes.OrderByDescending(w => w.ClientID).First();
                    SubscripcionManager.CrearSubscripcionNueva(cli);
                    return RedirectToAction("SeleccionarPlan",new{clienteid = cli.ClientID});
                }
            }
            else
            {
                ModelState.AddModelError("Email", "El Correo que intenta utilizar ya existe");
            }
            return HttpNotFound();
        }

       

        [Authorize(Roles = "VerCliente, ListarCliente")]
        public override ActionResult Index()
        {
            var clis = db.Clientes.ToList();
           
            return View(clis);
        }


        [Authorize(Roles = "ModificarCliente")]
        public override ActionResult Modificar(int id)
        {
            var cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ModificarCliente")]
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



        [Authorize]
        [Authorize(Roles = "VerCliente, ListarCliente")]
        public override ActionResult VerDetalles(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente != null)
            {
                if (cliente.Subscripcion.Active)
                {
                    ViewBag.estado = "Activo";
                }
                else ViewBag.estado = "Inactivo";
                ViewBag.ImgSrc = ImagenManager.RetornarSourceImagen(cliente.ImagenID);
                return View(cliente);
            }
            return HttpNotFound();
            
        }

        [Authorize(Roles = "CrearCliente")]
        public ActionResult SeleccionarPlan(int clienteid)
        {
            var plans = db.Plans.ToList();
            var cliente = db.Clientes.Find(clienteid);
            ViewBag.ClienteId = clienteid;
            return View(plans);
        }

        [Authorize(Roles = "CrearCliente")]
        public ActionResult PlanElegido(int PlanId, int ClienteId)
        {
            var cliente = db.Clientes.Find(ClienteId);
            if (cliente != null)
            {
                var subs = cliente.Subscripcion;
                if (db.Plans.Find(PlanId) != null)
                {
                    subs.PlanID = PlanId;
                    subs.Active = true;
                    db.Entry(subs).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return HttpNotFound();
                return RedirectToAction("VerDetalles", new {id = ClienteId});
            }
            return RedirectToAction("Index");
        }
    }
}