using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class ServiciosManager
    {

        private static MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();


        public static void ServicioModificado(int id, Servicio s)
        {
            var servicio = db.Servicios.Find(id);
            if(servicio != null) { 
            servicio.Nombre = s.Nombre;
            servicio.Precio = s.Precio;
                servicio.IDErick = s.IDErick;
                servicio.IDPedro = s.IDPedro;
            db.Entry(servicio).State = EntityState.Modified;
            db.SaveChanges();
            }
        }

        public static void ModificarListadoDeServicios(IEnumerable<Servicio> servicios)
        {
            foreach (var s in servicios)
            {
                ServicioModificado(s.ServicioID, s);
            }
        }


        public static void AgregarServicioDB(Servicio s)
        {
            db.Servicios.Add(s);
            db.SaveChanges();

        }


        public static void AgregarListadoDeServicios(IEnumerable<Servicio> s)
        {
            db.Servicios.AddRange(s);
            db.SaveChanges();
        }

        public static void BorrarListadoDeServicios(IEnumerable<Servicio> s)
        {
           
            foreach(var i in s)BorrarServicios(i);
        }


        public static void BorrarServicios(Servicio s)
        {
            var p = db.Servicios.Find(s.ServicioID);
            if (p != null)
            {
                var servplan = db.ServicioEnPlans.Where(x => x.ServicioID == p.ServicioID).ToList();
                if (servplan.Any())
                {
                    db.ServicioEnPlans.RemoveRange(servplan);   
                }
                db.Servicios.Remove(p);
            }
            db.SaveChanges();
        }

       


    }
}