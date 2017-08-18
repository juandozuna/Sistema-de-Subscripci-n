using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class PlanManager:AControl   
    {
        public PlanManager() { WControlledP = "Planes"; WControlledS = "Plan"; }
        public override void Agregar() { }
        public override void Editar() { }
        public override void Buscar() { }
        public override void Borrar() { }
    }
}
