using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public abstract class AControl
    {

        protected ProyectProgramacionIIIEntities db = new ProyectProgramacionIIIEntities(); //Tomar en cuenta declaracion de variable al eliminar y recrear la instalacion de EntityFramework
        public static string WControlledP; //Contiene una descripcion de lo que esta siendo controlado (1. CLientes, 2. Servicios, 3. Planes)
        public static string WControlledS;

        public abstract void Agregar();
        public abstract void Editar();
        public abstract void Buscar();
        public abstract void Borrar();
        public abstract void ListarDatos();
    }
}
