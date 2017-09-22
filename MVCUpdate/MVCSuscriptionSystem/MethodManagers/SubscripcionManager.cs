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
                //ClientID = cliente.ClientID,
            };
            var ClienteSuscripcion = new ClienteSuscripcion(){ClienteId = cliente.ClientID};
            using (EntityModel db = new EntityModel())
            {
                db.Subscripcions.Add(sus);
                db.SaveChanges();
                sus = db.Subscripcions.OrderByDescending(w => w.SubscripcionID).First();
                ClienteSuscripcion.SubscripcionId = sus.SubscripcionID;
                db.ClienteSuscripcions.Add(ClienteSuscripcion);

                db.SaveChanges();
            }
        }

        public static void PlanSelectedActivatePlan(int PlanId, Subscripcion subs)
        {
            using (EntityModel db = new EntityModel())
            {
                subs.PlanID = PlanId;
                subs.Active = true;
                db.Entry(subs).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}