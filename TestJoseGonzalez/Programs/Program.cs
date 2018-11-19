using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJoseGonzalez.Programs;

namespace TestJoseGonzalez
{
    class Program
    {
        static void Main(string[] args)
        {
            EscuchandoSonido Escuchar = new EscuchandoSonido();
            Escuchar.Iniciar();
            string Continuar = string.Empty;
            Console.WriteLine("¿ Desea Continuar ? \n Presiones 1 si desea Volver a buscar \n Presione 2 si desea Salir.");
            Continuar = Console.ReadLine();

            switch (Continuar)
            {
                case "1":
                    Console.Clear();
                    Escuchar.Iniciar();
                    break;
                case "2":
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Tecla no Valida, La consola se cerrara...");
                    Console.ReadKey();
                    break;
            }






        }
    }
}
