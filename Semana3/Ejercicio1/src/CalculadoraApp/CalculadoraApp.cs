using System;
using CalculadoraLib;

class CalculadoraApp
{
    static void Main()
    {
        var calc = new Calculadora();

        Console.WriteLine("=== Calculadora POO ===");
        Console.WriteLine("Elije el primer número:");
        double  num1 =  double.Parse(Console.ReadLine()!);

        Console.WriteLine("Elije el segundo número:");
        double  num2 =  double.Parse(Console.ReadLine()!);

        Console.WriteLine($"{num1} + {num2} = " + calc.Sumar(num1, num2));
        Console.WriteLine($"{num1} - {num2} = " + calc.Restar(num1, num2));
        Console.WriteLine($"{num1} * {num2} = " + calc.Multiplicar(num1, num2));
        Console.WriteLine($"{num1} / {num2} = " + calc.Dividir(num1, num2));
        Console.WriteLine($"{num1} ^ {num2} = " + calc.Potencia(num1, num2));
        Console.WriteLine($"Raíz de {num1} = " + calc.RaizCuadrada(num1));
        Console.WriteLine($"Raíz de {num2} = " + calc.RaizCuadrada(num2));

        Console.WriteLine($"\nOperaciones realizadas: {calc.OperacionesRealizadas}");
    }
}
