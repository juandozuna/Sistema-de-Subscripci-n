﻿using MVCSuscriptionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Security;
using MVCSuscriptionSystem.HttpClients.HttpMethods.ServiciosJoined;
using MVCSuscriptionSystem.MethodManagers;

namespace MVCSuscriptionSystem.Controllers
{
    [Authorize]
    public class ServicioController : ProgramManager
    {

        private ServiciosFromServices manager = new ServiciosFromServices();

        [Authorize(Roles = "BorrarServicio")]
        public override ActionResult Borrar(int id)
        {
            var servi = db.Servicios.Find(id);
            return View(servi);
        }

        [HttpPost, ActionName("Borrar")]
        [Authorize(Roles = "BorrarServicio")]
        public ActionResult ConfirmarBorrar(int id)
        {
            var servicio = db.Servicios.Find(id);
            if (servicio != null)
            {
             ServiciosManager.BorrarServicios(servicio);
             if(!manager.BorrarServicio(servicio)) return HttpNotFound();
             return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "CrearServicio")]
        public override ActionResult Crear()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="CrearServicio")]
        public ActionResult Crear(Servicio servicio)
        {
            if (servicio != null)
            {
                db.Servicios.Add(servicio);
                manager.CrearServicioPedro(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        [Authorize(Roles = "VerServicio, ListarServicio")]
        public override ActionResult Index()
        {
            manager.GetServicios();
            var servicios = db.Servicios;
            return View(servicios.ToList());
        }


        [Authorize(Roles = "ModificarServicio")]
        public override ActionResult Modificar(int id)
        {
            var servicio = db.Servicios.Find(id);
            if (servicio != null)
            {

                return View(servicio);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ModificarServicio")]
        public  ActionResult Modificar(Servicio servicio)
        {
            var s = db.Servicios.Find(servicio.ServicioID);
            if (s != null)
            {
                ServiciosManager.ServicioModificado(servicio.ServicioID, servicio);
                manager.ModificarServicio(s);
                
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }


        [Authorize(Roles = "VerServicio, ListarServicio")]
        public override ActionResult VerDetalles(int id)
        {
            var s = db.Servicios.Find(id);
            if (s!=null)
                return View(s);
            return HttpNotFound();
        }
    }
}