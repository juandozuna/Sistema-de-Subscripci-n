using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class ServiceManager : AControl
    {
        public ServiceManager() { WControlledP = "Servicios"; WControlledS = "Servicio"; }
        public override void Agregar() { }
        public override void Editar() { }
        public override void Buscar() { }
        public override void Borrar() { }
        public override void ListarDatos() { }
    }
}
