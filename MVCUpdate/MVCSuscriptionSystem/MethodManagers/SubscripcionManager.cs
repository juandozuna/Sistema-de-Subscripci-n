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
                PlanID = 1
                //ClientID = cliente.ClientID,
            };
            int? idN = cliente.ClientID;
            var ClienteSuscripcion = new ClienteSuscripcion(){ClienteId = cliente.ClientID, Cliente_ClientID = idN};
            using (MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities())
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
            using (MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities())
            {
                subs.PlanID = PlanId;
                subs.Active = true;
                db.Entry(subs).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private static void pruebas()
        {
            
        }
    }
}