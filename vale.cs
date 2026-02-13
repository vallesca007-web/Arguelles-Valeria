using System;
using System.Collections.Generic;
using System.Data;

namespace EdadesFiltros
{
    internal class Program
    {
        //Creacion de la clase personas 
        public class Personas
        {
            public string nombre { get; set; }
            public int edad { get; set; }

            public Personas(string nombre, int edad)
            {
                this.nombre = nombre; //para que las que se llamen asi como locales se conviertan en estas
                this.edad = edad;
            }
        }

        static void Main(string[] args)
        {
            int cantidadPersona = LeerNumero("Cuantas personas vas a contabilizar: ");

            Proceso(cantidadPersona);

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey(); //Esperar a que se presione una tecla para continuar
        }

        public static int LeerNumero(string error)
        {
            int resultado;
            while (true)
            {
                Console.Write(error);
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out resultado) && resultado > 0) //Verificar que lo introducido sea numerico y mayor a 0
                {
                    return resultado; //si es valido regresar el int
                }
                Console.WriteLine("Ingrese un valor valido"); //si no es valido regresar el texto de error
            }
        }

        public static void Proceso(int cantidadPersona)
        {
            if (cantidadPersona == 1)
            {
                UnaPersona();
            }
            else
            {
                MasPersonas(cantidadPersona);
            }
        }

        public static void UnaPersona()
        {
            int edadPersona = LeerNumero("Ingresa la edad de la persona: "); //Imprime el texto en el parentesis mientras se ejecuta LeerNumero
            Console.Write("Ingresa el nombre de la persona: ");
            string nombrePersona = Console.ReadLine();
            if (edadPersona >= 18) //verificar si la persona es mayor de edad
            {
                Console.WriteLine($"\nTu persona es:\n{nombrePersona} de {edadPersona} años, es mayor de edad"); //imprimir los textos de mayor
            }
            else
            {
                Console.WriteLine($"\nTu persona es:\n{nombrePersona} de {edadPersona} años, es menor de edad"); //de otra manera imprimir los de menor
            }
        }

        public static void MasPersonas(int cantidadPersona)
        {
            string nombrePersona;
            List<Personas> mayores = new List<Personas>(); //crear una lista donde se guardaran objetos de la clase
            List<Personas> menores = new List<Personas>();

            for (int i = 0; i < cantidadPersona; i++)
            {
                Console.Write("\nIntroduce el nombre de la persona " + (i + 1) + ": ");
                String nombre = Console.ReadLine();
                int edad = LeerNumero("Ingresa la edad de la persona " + (i + 1) + ": ");
                Console.WriteLine("");

                Personas nuevaPersona = new Personas(nombre, edad); //crear el objeto que recibe nombre y edad como parametro
                if (edad >= 18)
                {
                    mayores.Add(nuevaPersona); //crea un objeto dependiendo si hay o no mayores
                }
                else
                {
                    menores.Add(nuevaPersona);
                }

            }
            Imprimir(mayores, menores);
        }

        public static void Imprimir(List<Personas> mayores, List<Personas> menores) //recibe las listar para poder trabajar con ellas
        {
            Console.WriteLine("--Lista completa de personas--");
            foreach (Personas personas in mayores) //por cada personas (tipo de var) en mayores acceder a  cada personas (la variable)
            {
                Console.WriteLine($"\t{personas.nombre} quien tiene {personas.edad} años"); //acceder a las variables dentro del objeto
            }
            foreach (Personas personas in menores)
            {
                Console.WriteLine($"\t{personas.nombre} quien tiene {personas.edad} años");
            }
            Console.WriteLine("\nPresione una tecla para ver la lista ordenada");
            Console.ReadKey();

            Console.Clear();
            if (mayores.Count > 0)
            {
                Console.WriteLine("----Tus personas mayores fueron----");
                foreach (Personas personas in mayores)
                {
                    Console.WriteLine($"\t {personas.nombre} quien tiene {personas.edad} años");
                }

            }

            if (menores.Count > 0)
            {
                Console.WriteLine("\n----Tus personas menores fueron----");
                foreach (Personas personas in menores)
                {
                    Console.WriteLine($"\t {personas.nombre} quien tiene {personas.edad} años");
                }
            }
        }
    }
}

