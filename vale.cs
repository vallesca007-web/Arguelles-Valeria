using System;
using System.Collections.Generic; // Necesario para el uso de listas

namespace EdadesFiltros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantidad = LeerNumero("¿Cuántas personas vas a contabilizar?: "); //llama al metodo LeerNumero y le manda el string

            // Declaración de Listas
            List<string> nombres = new List<string>();
            List<int> edades = new List<int>();

            for (int i = 0; i < cantidad; i++) //Un for que va del 0 al numero que el usuario indico
            {
                Console.WriteLine($"\n--- Registro Persona {i + 1} ---"); //i +1 para que no aparezca desde 0
                Console.Write("Nombre: ");
                nombres.Add(Console.ReadLine()); //añade lo que lee a la lista de nombres

                int edad = LeerNumero("Edad: "); //Vuelve a llamar a la verificacion de enteros 
                edades.Add(edad); //añade el int a la lista de edades
            }

            ImprimirResultados(nombres, edades); //llama el metodo y le manda las listas

            Console.WriteLine("\nPresiona cualquier tecla para salir..."); 
            Console.ReadKey(); //espera alguna tecla para continuar
        }

        public static int LeerNumero(string mensaje) //recibe el mensaje que se pone al llamarlo
        {
            int resultado;
            while (true) //crea un bucle infinito, es decir no va a parar hasta un break o un return 
            {
                Console.Write(mensaje); //imprime el mensaje que recibio al ser llamado
                if (int.TryParse(Console.ReadLine(), out resultado) && resultado > 0) //intenta convertir lo que se lee a int y verifica que sea mayor a 0
                {
                    return resultado; //si se cumplieron ambas condiciones devuelve resultado y se acaba el bucle
                }
                Console.WriteLine("Error: Ingresa un número entero positivo."); //si no se cumplio alguna condicion muestra error y se repite el bucle
            }
        }

        public static void ImprimirResultados(List<string> nombres, List<int> edades) //recibe las listas
        {
            Console.Clear(); //limpia la pantalla

            // 1. LISTA GENERAL (Solo si hay más de una persona)
            if (nombres.Count > 1) //verifica que haya mas de una persona antes de crear la lista general
            {
                Console.WriteLine("========== LISTADO GENERAL DE PERSONAS ==========");
                //nombres.Count significa que se devuelve como entero el total del indice de la lista
                for (int i = 0; i < nombres.Count; i++) //Va desde el indice 0 de la lista hasta el final
                {
                    Console.WriteLine($"{i + 1}. {nombres[i]} - {edades[i]} años"); //accede a la posicion de cada lista siendo que i al cambiar hasta el final para por todas
                }
                Console.WriteLine("================================================\n");
            }

            // 2. CONTEO (Lógica idéntica a la anterior)
            int conteoMayores = 0;
            int conteoMenores = 0;

            for (int i = 0; i < edades.Count; i++)
            {
                if (edades[i] >= 18) conteoMayores++; //verifica si la edad en dicha posicion es mayor
                else conteoMenores++;
            }

            // 3. MOSTRAR MAYORES
            if (conteoMayores > 0) //si si hay mayores 
            {
                Console.WriteLine("--- Personas Mayores de Edad ---");
                for (int i = 0; i < nombres.Count; i++) //accede a todos los datos de las filas 
                {
                    if (edades[i] >= 18)
                        Console.WriteLine($"- {nombres[i]} ({edades[i]} años)"); //imprime solo los mayores
                }
            }

            // 4. MOSTRAR MENORES
            if (conteoMenores > 0) //verifica que haya menores 
            {
                Console.WriteLine("\n--- Personas Menores de Edad ---");
                for (int i = 0; i < nombres.Count; i++)
                {
                    if (edades[i] < 18)
                        Console.WriteLine($"- {nombres[i]} ({edades[i]} años)"); //imprime solo los menores 
                }
            }
        }
    }
}
