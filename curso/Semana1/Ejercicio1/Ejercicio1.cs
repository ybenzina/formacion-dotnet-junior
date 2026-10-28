using System;

namespace Ejercicios
{
    // Ejemplo de definición de clase
    public class Persona
    {
        private string nombre;
        private int edad;

        //Constructor
        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public void MenorMayor()
        {
            // Ejemplo de condicional if/else:
            if (edad >= 18)
            {
                Console.WriteLine($"{nombre} es mayor de edad");
            }
            else
            {
                Console.WriteLine($"{nombre} es menor de edad");
            }
        }

        public static void Main(string[] args)
        {
            // Ejemplo de bucle for
            Console.WriteLine("Ejemplo de bucle for:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Número: {i}");
            }

            // Ejemplo de condicional if/else con clases:
            Console.WriteLine("\nEjemplo de if/else:");
            Persona persona = new Persona("Juan", 20);
            Persona persona2 = new Persona("Pepe", 15);
            persona.MenorMayor();
            persona2.MenorMayor();
        }
    }
}
