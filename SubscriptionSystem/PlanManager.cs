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
        public override void Agregar()
        {
            if (db.Servicios.Any())
            {
                var name = "empty for now"; //Resibe el nobmre que el usuario le da al plan.
                List<int> ServiceIDs = new List<int>();
                Console.Clear();
                Console.WriteLine("Agregar un Nuevo Plan"); bool test = true;
                do
                {
                    Console.Write("1. Elija los servicios que quiere agregar en el plan \n" +
                        "------------------------------------------------------------------\n");
                    foreach (Servicio a in db.Servicios) Console.WriteLine("       Item: {0} | Servicio: {1}", a.ServicioID, a.Nombres);
                    Console.Write("Escirba el numero del servicio que desea agregar al plan: "); Int32.TryParse(Console.ReadLine(), out int ID);
                    ServiceIDs.Add(ID);
                    Console.WriteLine("Desea agregar mas servicios? 1-Si / 2-No"); Int32.TryParse(Console.ReadLine(), out int cont);
                    Console.Clear();
                    if (cont == 1) continue; test = false;
                } while (test);
                Console.Write("El plan tendra los siguientes servicios:\n");
                foreach (int a in ServiceIDs)
                {
                    var serviceResult = db.Servicios.SingleOrDefault(b => b.ServicioID == a);
                    Console.WriteLine("      -->Item: {0}  | Servicio: {1} ", serviceResult.ServicioID, serviceResult.Nombres);
                }
                Console.Write("Elija el nombre del plan: "); name = Console.ReadLine();
                Console.Write("Cual sera el precio del plan(UTILIZE ESTE FORMATO 0.00)? -->"); Double.TryParse(Console.ReadLine(), out double precio);


                Plane plan = new Plane()
                {
                    Nombre = name,
                    Precio = precio

                };
                db.Planes.Add(plan); db.SaveChanges();
                plan = db.Planes.SingleOrDefault(b => b.Nombre == name); int contar;
                if (db.ServPlans.Any()) contar = db.ServPlans.Count()+1; else contar = 1;
                foreach (int a in ServiceIDs)
                {
                    ServPlan servp = new ServPlan() {ServPlanID = contar++, PlanID = plan.PlanID, ServicioID = a };
                    db.ServPlans.Add(servp);
                }

                db.SaveChanges();
               

                Console.WriteLine("Desea agregar otro plan? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) { Console.Clear(); this.Agregar(); }
            else Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Para crear un plan primero debe de crear servicios");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }


        }
        public override void Editar()
        {
            Console.Clear();
            Console.WriteLine("####### EDITAR PLANES ########");
            Console.Write("Escriba el ID del plan que desea modificar: "); Int32.TryParse(Console.ReadLine(), out int UI1);// UI = User Input
            var result = db.Planes.SingleOrDefault(b => b.PlanID == UI1);
            if(result != null)
            {
                bool val = false;
                do
                {
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine("[ID:{0}]\n1)PLAN: {1}\n2)PRECIO: {2:RD$0.00} ", result.PlanID, result.Nombre, result.Precio);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    foreach (ServPlan a in result.ServPlans) Console.WriteLine("  [ITEM:{0}] | SERVICIO:{1} ", a.Servicio.ServicioID, a.Servicio.Nombres);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.Write("Que desea modificar?\n" +
                        "1. Nombre del Plan\n" +
                        "2. Precio del Plan\n" +
                        "3. Agregar Servicios\n" +
                        "4. Quitar Servicios\n" +
                        "5. Terminar de Editar\n" +
                        "Seleccion: "); Int32.TryParse(Console.ReadLine(), out UI1);
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    switch (UI1)
                    {
                        case 1:
                            Console.Write("Escriba el nombre del plan: "); result.Nombre = Console.ReadLine();
                            db.SaveChanges();
                            val = false;
                            break;
                        case 2:
                            Console.Write("Ponga un nuevo precio para el plan (FORMATO 0.00): "); Double.TryParse(Console.ReadLine(), out double precio); result.Precio = precio;
                            db.SaveChanges();
                            val = false;
                            break;
                        case 3:
                            AgregarServicio(result);
                            val = false;
                            break;
                        case 4:
                            EliminarServicios(result);
                            val = false;
                            break;
                        case 5:
                            val = true;
                            break;
                        default:                     
                            Console.WriteLine("Ingreso un valor invalido");
                            break;
                         
                    }
                    if (val) break;               
                    Console.WriteLine("Desea continuar editando? 1-SI / 2-NO");
                    if (Int32.Parse(Console.ReadLine()) == 1) val = true; else val = false;
                    
                    Console.Clear();
                } while (val);
                
            }
            else
            {
                Console.WriteLine("El Plan que intenta editar no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) Editar();
                else Console.WriteLine("Presione cualquier tecla para continuar");
            }
            Console.ReadKey();

        }
        private void AgregarServicio(Plane pl)
        {
            Console.WriteLine("SERVICIOS DISPONIBLES");
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach (Servicio a in db.Servicios) Console.WriteLine("   [ITEM:{0}] | SERVICIO: {1}", a.ServicioID, a.Nombres);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.Write("Escirba el numero del servicio que desea agregar al plan: "); Int32.TryParse(Console.ReadLine(), out int ID);
            var service = db.Servicios.SingleOrDefault(b => b.ServicioID == ID); int contar;
            if (db.ServPlans.Any()) contar = db.ServPlans.Count() + 1; else contar = 1;
            if (service != null)
            {
                db.ServPlans.Add(new ServPlan() { ServicioID = service.ServicioID, PlanID = pl.PlanID, ServPlanID = contar });
                db.SaveChanges();
                Console.WriteLine("Desea agregar mas servicios? 1-Si / 2-No"); Int32.TryParse(Console.ReadLine(), out int cont);
                if (cont == 1) {AgregarServicio(pl); }
            }
            else
            {
                Console.WriteLine("El servicio que buscaba no existe");
                Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }
           

        }
        private void EliminarServicios(Plane pl)
        {
            Console.WriteLine("SERVICIOS CONTENIDOS EN EL PLAN");
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach(ServPlan a in pl.ServPlans) { Console.WriteLine("   [ITEM:{0}] | SERVICIO: {1}", a.Servicio.ServicioID, a.Servicio.Nombres); }
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.Write("Escriba el ID del Servicio que desea eliminar del Plan: "); Int32.TryParse(Console.ReadLine(), out int UI);//UI for user input
            var result = pl.ServPlans.SingleOrDefault(b => b.ServicioID == UI);
            if(result != null)
            {
                db.ServPlans.Remove(result);
                db.SaveChanges();
                Console.WriteLine("Desea quitar mas servicios del Plan? 1-Si / 2-No"); Int32.TryParse(Console.ReadLine(), out int cont);
                if (cont == 1) { EliminarServicios(pl); }
            }
            else
            {
                Console.WriteLine("El servicio que buscaba no existe en este plan");
                Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }
            
        }

        public override void Buscar()
        {
            Console.Clear();
            Console.WriteLine("######## BUSCAR PLANES ########");
            Console.Write("Escriba el ID del plan que desea buscar: "); Int32.TryParse(Console.ReadLine(), out int input);
            var result = db.Planes.SingleOrDefault(b => b.PlanID == input);
            if (result != null)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("El plan con el ID:{0} fue encontrado", result.PlanID);
                Console.WriteLine("" +
                    " ---> ID: {2}" +
                    " ---> PLAN: {0}\n" +
                    " ---> PRECIO: {1:0.00}", result.Nombre, result.Precio, result.PlanID);
                Console.WriteLine("Servicios contenidos en plan:");
                Console.WriteLine("------------------------------------------------------------");
                foreach(ServPlan a in result.ServPlans) Console.WriteLine("   --> [ITEM: {0}] | SERVICIO: {1}", a.ServicioID, a.Servicio.Nombres);
            }
            else
            {
                Console.WriteLine("El Plan que buscaba no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) Buscar();
                else Console.WriteLine("Presione cualquier tecla para continuar");
            }
            Console.ReadKey();
        }
        public override void Borrar()
        {
            Console.Clear();
            Console.WriteLine("######## BORRAR PLAN ########");
            Console.Write("Escriba el ID del plan que desea borrar: "); string UI = Console.ReadLine(); Int32.TryParse(UI, out int IntUI);
            var result = db.Planes.SingleOrDefault(b => b.PlanID == IntUI);
            if (result != null)
            {
                
                var group = db.ServPlans.Where(x => db.ServPlans.Any(y => y.PlanID == result.PlanID));
                foreach (ServPlan a in group) db.ServPlans.Remove(a);
                db.Planes.Remove(result); db.SaveChanges();
                Console.WriteLine("El plan con ID:{0} ha sido borrado exitosamente\nPresione cualquier tecla para continuar", result.PlanID); Console.ReadKey();

            }
            else
            {
                Console.WriteLine("El Plan con ID {0} que intenta buscar no existe", UI);
                Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }
        }
        public override void ListarDatos()
        {
            Console.Clear();
            Console.WriteLine("######## LISTA DE PLANES ######## Planes existentes: {0}", db.Planes.Count());
            Console.WriteLine("---------------------------------------------------------------------------");
            foreach(Plane a in db.Planes)
            {
                Console.WriteLine("[ID:{0}] PLAN: {1}  |  PRECIO: {2:RD$0.00}", a.PlanID, a.Nombre, a.Precio);
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
