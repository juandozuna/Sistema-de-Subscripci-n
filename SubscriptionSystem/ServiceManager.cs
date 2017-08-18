using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class ServiceManager : AControl
    {
        private string nombre;
        private double precio_unidad;

        public ServiceManager() { WControlledP = "Servicios"; WControlledS = "Servicio"; }
        public override void Agregar()
        {          
            Console.Clear();
            Console.WriteLine(" ######### AGREGAR SERVICIOS ########  SERVICIOS EXISTENTES {0}", db.Servicios.Count());
            Console.Write("Nombre del servicio a ofrecer: "); nombre = Console.ReadLine();
            Console.Write("Precio del servicio a ofrecer: "); Double.TryParse(Console.ReadLine(), out precio_unidad);


            Servicio servicio = new Servicio()
            {
                Nombres = nombre,
                PrecioUnidad = precio_unidad
            };

            db.Servicios.Add(servicio); db.SaveChanges();

            Console.WriteLine("Desea agregar otro servicio? 1-SI / 2-NO");
            if (Int32.Parse(Console.ReadLine()) == 1) { Console.Clear(); Agregar(); }
            else Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
        public override void Editar()
        {
            Console.Clear();
            Console.WriteLine("######## EDITAR SERVICIOS ########");
            Console.Write("Escriba el ID del servicio que desea modificar: "); Int32.TryParse(Console.ReadLine(), out int UI);
            var result = db.Servicios.SingleOrDefault(b => b.ServicioID == UI);
            if(result != null)
            {
                bool val = false;
                do
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine("ITEM ID: {0}\n" +
                        "SERVICO: {1}\n" +
                        "PRECIO UNITARIO: {2}", result.ServicioID, result.Nombres, result.PrecioUnidad);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.Write("Que desea modificar?\n" +
                        "1) El nombre del servicio \n" +
                        "2) El precio del Servicio\n" +
                        "Seleccion: "); Int32.TryParse(Console.ReadLine(), out UI);
                    switch (UI)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nuevo nombre del servicio: ");
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nuevo precio del servicio: "); Double.TryParse(Console.ReadLine(), out precio_unidad);
                            result.PrecioUnidad = precio_unidad;
                            break;
                        default:
                            Console.WriteLine("Ha ingresado un valor invalido");
                            break;
                    }

                    Console.WriteLine("Desea continuar editando? 1-SI / 2-NO");
                    if (Int32.Parse(Console.ReadLine()) == 1) val = true; else val = false;

                } while (val);

            }
            else
            {
                Console.WriteLine("El el servicio que intento editar no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) Editar();
                else Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }
        }
        public override void Buscar()
        {
            Console.Clear();
            Console.WriteLine("######## BUSCAR SERVICIOS ########");
            Console.Write("Escriba el ID del servicio que desea buscar: "); Int32.TryParse(Console.ReadLine(), out int input);
            var result = db.Servicios.SingleOrDefault(b => b.ServicioID == input);
            if (result != null)
            {         
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("El servicio con el ID:{0} fue encontrado", result.ServicioID);
                Console.WriteLine("" +
                    " ---> ID: {2}" +
                    " ---> SERVICIO: {0}\n" +
                    " ---> PRECIO UNITARIO: {1:0.00}",result.Nombres, result.PrecioUnidad, result.ServicioID);
            }
            else
            {
                Console.WriteLine("El Servicio que buscaba no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) Buscar();
                else Console.WriteLine("Presione cualquier tecla para continuar");
            }
            Console.ReadKey();
        }
        public override void Borrar()
        {
            Console.Clear();
            Console.WriteLine("######## BORRAR SERVICIO ########");
            Console.Write("Escriba el ID del servicio que desea borrar"); string UI = Console.ReadLine();
            var result = db.Servicios.SingleOrDefault(b => b.ServicioID == Int32.Parse(UI));
            if(result != null)
            { 
                var group = db.ServPlans.Where(x => db.ServPlans.Any(y => y.ServicioID == result.ServicioID));
                foreach(ServPlan a in group) db.ServPlans.Remove(a);
                db.Servicios.Remove(result);
                db.SaveChanges();
                Console.WriteLine("El plan con ID:{0} ha sido borrado exitosamente\nPresione cualquier tecla para continuar"); Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Servicio con ID {0} que intenta buscar no existe", UI);
                Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }
        }
        public override void ListarDatos()
        {
            Console.Clear();
            Console.WriteLine("######## LISTA DE SERVICIOS #########  Servicios Existentes: {0}", db.Servicios.Count());
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach(Servicio a in db.Servicios)
            {
                Console.WriteLine("[ID:{0}]  SERVICIO: {1}  | PRECIO UNITARIO: {2:RD$0.00}", a.ServicioID, a.Nombres, a.PrecioUnidad);
            }
            Console.WriteLine("\n Presiones cualquier tecla para continuar"); Console.ReadKey();
        }
    }
}
