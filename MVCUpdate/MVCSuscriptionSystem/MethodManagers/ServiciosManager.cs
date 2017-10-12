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
            servicio.Nombre = s.Nombre;
            servicio.Precio = s.Precio;
            db.Entry(servicio).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void ModificarListadoDeServicios(IEnumerable<Servicio> servicios)
        {
            foreach (var  i in COLLECTION)
            {
                
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


    }
}