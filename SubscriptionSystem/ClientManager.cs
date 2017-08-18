using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class ClientManager : AControl
    {
        string nombre;
        string apellido;
        string metodoDePago;
        private Cliente cliente;
        public ClientManager()
        {
            WControlledS = "Cliente";
            WControlledP = "Clientes";
        }

        public override void Agregar()
        {          
            int mp; 
            Console.Clear();
            Console.WriteLine("AGREGAR CLIENTE");
            Console.Write("Nombre: "); nombre = Console.ReadLine();
            Console.Write("Apellido: "); apellido = Console.ReadLine();
            bool test = false;
            do
            {
                Console.Write("Metodo de Pago (1.Tarjeta de Credito, 2.Tarjeta de Debito, 3.Paypal): "); Int32.TryParse(Console.ReadLine(), out mp);
                if (mp >= 4) test = true; else if (mp <= 0) test = true; else test = false;
                switch (mp)
                {
                    case 1:
                        metodoDePago = "Tarjeta de Credito";
                        break;
                    case 2:
                        metodoDePago = "Tarjeta de Debito";
                        break;
                    case 3:
                        metodoDePago = "PayPal";
                        break;
                }

            } while (test);

            cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                MetodoDePago = metodoDePago
            };
           
            SetPlan();
            
            db.Clientes.Add(cliente);
            db.SaveChanges();
            Console.WriteLine("Cliente agregado exitosamente");
            Console.Clear();
            Console.WriteLine("Desea agregar otro cliente? 1-SI / 2-NO");
            if (Int32.Parse(Console.ReadLine()) == 1) this.Agregar();
            else Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey(); 
        }
        public override void Editar()
        {
            Console.Clear();
            Console.WriteLine("####### EDITAR CLIENTE #######");
            Console.Write("Escriba el ID del cliente a Editar: "); Int32.TryParse(Console.ReadLine(), out int Uid);
            var result = db.Clientes.SingleOrDefault(b => b.ClienteID == Uid);
            if (result != null)
            {
                bool test = false;
                do
                {
                    string planText;
                    if (result.Plane != null) planText = cliente.Plane.Nombre; else planText = "No plan selected";
                    Console.WriteLine("Datos del Cliente ID: {4} \n" +
                        "1.Nombre: {0} \n" +
                        "2.Apellido: {1} \n" +
                        "3.Metodo de Pago: {2} \n" +
                        "4.Plan: {3}",result.Nombre, result.Apellido, result.MetodoDePago, planText, result.ClienteID);
                    Console.Write("Seleccione: "); Int32.TryParse(Console.ReadLine(), out int input);
                    switch (input)
                    {
                        case 1:
                            Console.Write("Ingrese el nombre editado: "); nombre = Console.ReadLine();
                            result.Nombre = nombre; db.SaveChanges();
                            break;
                        case 2:
                            Console.Write("Ingrese el apellido editado: "); apellido = Console.ReadLine();
                            result.Apellido = apellido; db.SaveChanges();
                            break;
                        case 3:
                            int mp = 1;
                            bool val = false;
                            do
                            {
                                Console.Write("Metodo de Pago (1.Tarjeta de Credito, 2.Tarjeta de Debito, 3.Paypal): "); Int32.TryParse(Console.ReadLine(), out mp);
                                if (mp >= 4) val = true; else if (mp <= 0) val = true; else val = false;
                                switch (mp)
                                {
                                    case 1:
                                        metodoDePago = "Tarjeta de Credito";
                                        break;
                                    case 2:
                                        metodoDePago = "Tarjeta de Debito";
                                        break;
                                    case 3:
                                        metodoDePago = "PayPal";
                                        break;
                                }
                                result.MetodoDePago = metodoDePago; db.SaveChanges();

                            } while (val);
                            break;
                        case 4:
                            cliente = result;
                            SetPlan();
                            db.SaveChanges();
                            break;
                    }

                    db.SaveChanges();
                    Console.WriteLine("Desea seguir editando? 1-SI / 2-NO");
                    if (Int32.Parse(Console.ReadLine()) == 1) test = true; else test = false;
                    Console.Clear();
                } while (test); //TERMINAR FUNCION

            }
            else
            {
                Console.WriteLine("El Cliente que buscaba no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) this.Editar();
                else Console.WriteLine("Presione cualquier tecla para continuar");
            }
            Console.ReadKey();




        }
        public override void Buscar()
        {
            Console.Clear();
            Console.WriteLine("######## BUSCAR CLIENTES ########");
            Console.Write("Escriba el ID del cliente que desea buscar: "); Int32.TryParse(Console.ReadLine(), out int input);
            var result = db.Clientes.SingleOrDefault(b => b.ClienteID == input);
            if(result != null)
            {
                string planText = "";
                if (result.Plane != null) planText = result.Plane.Nombre; else planText = "No tiene Plan";
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("El cliente con el ID:{0} fue encontraba", result.ClienteID);
                Console.WriteLine("" +
                    " ---> {0} {1}\n" +
                    " ---> Metodo de Pago: {2}\n" +
                    " ---> Plan: {3}", result.Nombre, result.Apellido, result.MetodoDePago, planText);
            }
            else
            {
                Console.WriteLine("El Cliente que buscaba no existe");
                Console.WriteLine("Desea volver a intentar? 1-SI / 2-NO");
                if (Int32.Parse(Console.ReadLine()) == 1) Buscar();
                else Console.WriteLine("Presione cualquier tecla para continuar");
            }
            Console.ReadKey();
        }
        public override void Borrar()
        {
            Console.Clear();
            Console.WriteLine("######## BORRAR CLIENTE ########");
            Console.Write("Escriba el ID del cliente que desea borrar: "); Int32.TryParse(Console.ReadLine(), out int input);
            var result = db.Clientes.SingleOrDefault(b => b.ClienteID == input);
            if(result != null)
            {
                Console.WriteLine("Cliente --> ID:{0} | {1}, {2} | Metodo de Pago: {3}",result.ClienteID, result.Apellido, result.Nombre, result.MetodoDePago);
                db.Clientes.Remove(result);
                db.SaveChanges();
                Console.WriteLine("El cliente ha sido eliminado exitosamente\nPresione cualquier tecla para continuar");Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El cliente que intenta borrar no existe");
                Console.WriteLine("Presione cualquier tecla para continuar"); Console.ReadKey();
            }


        }
        public override void ListarDatos()
        {
            Console.Clear();
            Console.WriteLine("######## LISTADO DE CLIENTES ########  Clientes en Existencia: {0}", db.Clientes.Count());
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            foreach(Cliente a in db.Clientes)
            {
                string planText = "";
                if (a.Plane != null) planText = a.Plane.Nombre; else planText = "No tiene Plan";
                Console.WriteLine("[ID:{4}] NOMBRE: {0} {1} | Metodo de Pago {2}\n" +
                    "       Plan Seleccionado: {3}\n", a.Nombre, a.Apellido, a.MetodoDePago, planText, a.ClienteID);
            }
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        private void SetPlan()
        {
            if (db.Planes.Any())
            {
                Console.Clear();
                Console.WriteLine("Estos son los planes que hay disponibles\n" +
                    "_______________________________________________________");
                foreach (Plane a in db.Planes)
                {
                    
                    Console.WriteLine("ID: {0} | PLAN: {1} | PRECIO: RD${2:0.00}", a.PlanID, a.Nombre, a.Precio);
                    foreach (ServPlan b in a.ServPlans)
                    {
                        Console.WriteLine("        SERVICIO: {0} | PRECIO UNIDAD: {1:0.00}", b.Servicio.Nombres, b.Servicio.PrecioUnidad);
                    }
                }
                Console.Write("Seleccione el plan que desea activar: "); Int32.TryParse(Console.ReadLine(), out int UI);
                var planResult = db.Planes.SingleOrDefault(b => b.PlanID == UI);
                cliente.PlanID = planResult.PlanID;
            }else
            {
                Console.WriteLine("Todavia no hay planes creados, debe de crear uno y luego volver a intentarlo");
            }

        }
       
    }
}
