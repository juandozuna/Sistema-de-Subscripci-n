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
            } while (test);

            cliente = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
            };
            cliente.SetMetodoPago(mp);

            if (db.Planes.Any())
            {
                Console.Clear();
                Console.WriteLine("Estos son los planes que hay disponibles\n" +
                    "_______________________________________________________");
                foreach(Plane a in db.Planes)
                {
                    Console.WriteLine("ID: {0} | PLAN: {1} | PRECIO: RD${2:0.00}", a.PlanID, a.Nombre, a.Precio); 
                    foreach(ServPlan b in a.ServPlans)
                    {
                        Console.WriteLine("        SERVICIO: {0} | PRECIO UNIDAD: {1:0.00}", b.Servicio.Nombres, b.Servicio.PrecioUnidad);
                    }
                }
                Console.Write("Seleccione el plan que desea activar: "); Int32.TryParse(Console.ReadLine(), out int UI);
                var planResult = db.Planes.SingleOrDefault(b => b.PlanID == UI);
                cliente.PlanID = planResult.PlanID;
            }
            
            db.Clientes.Add(cliente);
            db.SaveChanges();
            Console.WriteLine("Cliente agregado exitosamente");
            Console.Clear();
            Console.WriteLine("Desea agregar otro cliente? 1-SI / 2-NO");
            if (Int32.Parse(Console.ReadLine()) == 1) this.Agregar();
            else Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey(); 
        }
        public override void Editar() { }
        public override void Buscar() { }
        public override void Borrar() { }
    }
}
