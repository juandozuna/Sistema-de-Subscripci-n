using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSuscriptionSystem.Models;

namespace MVCSuscriptionSystem.MethodManagers
{
    public class PlanManager
    {
        private static MVCSuscriptionDatabseEntities db = new MVCSuscriptionDatabseEntities();
        public static void AgregarServicios(string[] servicios, Plan pl)
        {
             
            foreach (var s in servicios)
            {
                var sp = new ServicioEnPlan()
                {
                    PlanID = pl.PlanID,
                    ServicioID = Int32.Parse(s)
                };
                db.ServicioEnPlans.Add(sp);
            }
            db.SaveChanges();

        }
    }
}