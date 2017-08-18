using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramManager manager = new ProgramManager();

            int selection;
            do
            {
                Console.Clear();
                Console.WriteLine("######## Menu de {0} #########", AControl.WControlledP);
                Console.WriteLine("1. Agregar {0} \n" +
                    "2. Editar {0} \n" +
                    "3. Buscar {0} \n" +
                    "4. Borrar {0} \n" +
                    "5. Cambiar de Control \n" +
                    "6. Salir del Programa", AControl.WControlledS);
                Console.Write("Seleccion: "); Int32.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    case 1:
                        manager.Agregar(); break;
                    case 2:
                        manager.Editar(); break;
                    case 3:
                        manager.Buscar(); break;
                    case 4:
                        manager.Buscar(); break;
                    case 5:
                        manager.CambiarControl(); break;
                    case 6:
                        manager.SalidaPrograma(); break;
                    default:
                        manager.MetodoInvalido(); break;
                }

            } while (selection != 6);
        }
    }
}
