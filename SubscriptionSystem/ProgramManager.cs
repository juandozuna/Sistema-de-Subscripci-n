using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    public class ProgramManager
    {
       private AControl control;
       public ProgramManager()
        {
            Console.WriteLine("###### Bienvenido al Sistema de Suscripcion ######");
            Console.WriteLine("____________________________________________________\n" +
                "Elija con que desea trabajar:\n" +
                "1. Clientes\n" +
                "2. Servicios\n" +
                "3. Planes");
            Console.Write("Seleccion: ");
            control = ControlFactory.ControlObject(Console.ReadLine());
        }

        public void Agregar() { control.Agregar(); }     

        public void Editar() { control.Editar(); }

        public void Buscar() { control.Buscar(); }

        public void Borrar() { control.Borrar(); }

        public void CambiarControl()
        {
            
            Console.Clear(); 
            Console.WriteLine("Cambiar Control\n" +
                "____________________________________________________\n" +
               "Elija con que desea trabajar:\n" +
               "1. Clientes\n" +
               "2. Servicios\n" +
               "3. Planes");
            Console.Write("Seleccion: "); string UI = Console.ReadLine();
            control = ControlFactory.ControlObject(UI);
        }

        public void SalidaPrograma()
        {
            Console.Clear();
            Console.WriteLine("Gracias por haber utilizado nuestro sistema de Subscripcion\n\nPresione Cualquier tecla para continuar");
            Console.WriteLine("Este programa fue hecho por las siguientes personas\n" +
                "JUAN DANIEL OZUNA\n" +
                "DAVID DE LOS SANTOS\n" +
                "RICARDO VASQUEZ\n" +
                "ADRIAN SILVESTRE\n");
            Console.ReadKey();
        }

        public void MetodoInvalido()
        {
            Console.Clear();
            Console.WriteLine("Ha ingresado una opcion invalida, por favor vuelva a intentarlo\nPresione cualquier tecla para continuar"); Console.ReadKey();
        }

        public void ListarDatos()
        {
            control.ListarDatos();
        }

      
       

    }
}
