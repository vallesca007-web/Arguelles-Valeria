using System;
using System.Collections.Generic; 

namespace EdadesFiltros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantidad = LeerNumero("¿Cuántas personas vas a contabilizar?: "); 

            // Declaración de Listas
            List<string> nombres = new List<string>();
            List<int> edades = new List<int>();

            for (int i = 0; i < cantidad; i++) 
            {
                Console.WriteLine($"\n--- Registro Persona {i + 1} ---"); 
                Console.Write("Nombre: ");
                nombres.Add(Console.ReadLine()); 

                int edad = LeerNumero("Edad: "); 
                edades.Add(edad); 
            }

            ImprimirResultados(nombres, edades); 

            Console.WriteLine("\nPresiona cualquier tecla para salir..."); 
            Console.ReadKey(); 
        }

        public static int LeerNumero(string mensaje) 
        {
            int resultado;
            while (true) 
            {
                Console.Write(mensaje); 
                if (int.TryParse(Console.ReadLine(), out resultado) && resultado > 0) 
                {
                    return resultado; 
                }
                Console.WriteLine("Error: Ingresa un número entero positivo."); 
            }
        }

        public static void ImprimirResultados(List<string> nombres, List<int> edades) 
        {
            Console.Clear(); 

            // 1. LISTA GENERAL (Solo si hay más de una persona)
            if (nombres.Count > 1) //verifica que haya mas de una persona antes de crear la lista general
            {
                Console.WriteLine("========== LISTADO GENERAL DE PERSONAS ==========");
                //nombres.Count significa que se devuelve como entero el total del indice de la lista
                for (int i = 0; i < nombres.Count; i++) 
                {
                    Console.WriteLine($"{i + 1}. {nombres[i]} - {edades[i]} años"); 
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
            if (conteoMayores > 0) 
            {
                Console.WriteLine("--- Personas Mayores de Edad ---");
                for (int i = 0; i < nombres.Count; i++) 
                {
                    if (edades[i] >= 18)
                        Console.WriteLine($"- {nombres[i]} ({edades[i]} años)"); 
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

