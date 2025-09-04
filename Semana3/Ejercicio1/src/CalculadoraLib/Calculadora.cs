namespace CalculadoraLib;

public class Calculadora
{
    private int contadorOperaciones;

    public int OperacionesRealizadas => contadorOperaciones;

    public double Sumar(double a, double b)
    {
        contadorOperaciones++;
        return a + b;
    }

    public double Restar(double a, double b)
    {
        contadorOperaciones++;
        return a - b;
    }

    public double Multiplicar(double a, double b)
    {
        contadorOperaciones++;
        return a * b;
    }

    public double Dividir(double a, double b)
    {
        contadorOperaciones++;
        if (b == 0)
            throw new DivideByZeroException("No se puede dividir entre 0");
        return a / b;
    }

    public double Potencia(double baseNum, double exponente)
    {
        contadorOperaciones++;
        return Math.Pow(baseNum, exponente);
    }

    public double RaizCuadrada(double numero)
    {
        contadorOperaciones++;
        if (numero < 0)
            throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo");
        return Math.Sqrt(numero);
    }
}
