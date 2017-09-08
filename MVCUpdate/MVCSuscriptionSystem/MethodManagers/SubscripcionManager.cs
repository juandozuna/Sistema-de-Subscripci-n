using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class SubscripcionManager
    {
        public static void CrearSubscripcionNueva(Cliente cliente)
        {
            var sus = new Subscripcion()
            {
                Active = false,
                Fecha_creacion = DateTime.Now,
                ClientID = cliente.ClientID,
            };
            EntityModel db = new EntityModel();
            db.Subscripcions.Add(sus);
            db.SaveChanges();
            cliente.SubscripcionID = db.Subscripcions.OrderByDescending(d => d.SubscripcionID).First().SubscripcionID;
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}