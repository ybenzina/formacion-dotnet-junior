using System;

namespace Ejercicios
{
    public class EjerciciosNumericos
    {
        // Metodo FizzBuzz del 1 al 100
        public static void FizzBuzz()
        {
            Console.WriteLine("FizzBuzz (1-100):");
            for (int i = 1; i <= 100; i++)
            {
                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;
                if (fizz && buzz)
                    Console.Write("FizzBuzz ");
                else if (fizz)
                    Console.Write("Fizz ");
                else if (buzz)
                    Console.Write("Buzz ");
                else
                    Console.Write(i+" ");

                if (i % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        // Metodo factorial recursivo
        public static int Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        // Metodo para verificar si un numero es primo
        public static bool EsPrimo(int n)
        {
            // Si es menor o igual a 1, no es primo
            if (n <= 1) return false;
            
            // Si es 2 o 3, es primo, y si tiene un divisor distinto de 1 y sí mismo, no es primo
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        // Metodo para mostrar los primeros 20 numeros primos
        public static void Mostrar20Primos()
        {
            Console.WriteLine("Primeros 20 numeros primos:");
            int encontrados = 0;
            int numero = 0;
            
            while (encontrados < 20)
            {
                if (EsPrimo(numero))
                {
                    Console.Write($"{numero} ");
                    encontrados++;
                }
                numero++;
            }
            Console.WriteLine("\n");
        }

        public static void Main(string[] args)
        {
            // Ejecutar FizzBuzz
            FizzBuzz();

            // Mostrar factorial de algunos numeros
            Console.WriteLine("Factorial de numeros (0-10):");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"Factorial de {i} = {Factorial(i)}");
            }
            Console.WriteLine();

            // Mostrar primeros 20 numeros primos
            Mostrar20Primos();
        }
    }
}
