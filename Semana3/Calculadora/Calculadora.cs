using System;

namespace CalculadoraPOO
{
    public class Calculadora
    {
        // Encapsulación: campos privados
        private double resultado;

        public double Resultado => resultado;

        // Operaciones básicas
        public double Sumar(double a, double b)
        {
            resultado = a + b;
            return resultado;
        }

        public double Restar(double a, double b)
        {
            resultado = a - b;
            return resultado;
        }

        public double Multiplicar(double a, double b)
        {
            resultado = a * b;
            return resultado;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("No se puede dividir por cero.");
            resultado = a / b;
            return resultado;
        }

        // Operaciones avanzadas
        public double Potencia(double baseNum, double exponente)
        {
            resultado = Math.Pow(baseNum, exponente);
            return resultado;
        }

        public double Raiz(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("No se puede calcular la raíz de un número negativo.");
            resultado = Math.Sqrt(valor);
            return resultado;
        }
    }
}
