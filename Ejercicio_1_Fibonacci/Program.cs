using System;
using System.Collections.Generic; // Para usar List<int>

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el número de términos de la serie Fibonacci: ");
        string entrada = Console.ReadLine();

        int n;
        // Verifica si el valor ingresado es un número entero positivo
        if (int.TryParse(entrada, out n) && n > 0)
        {
            Console.WriteLine($"Números primos en los primeros {n} términos de Fibonacci:");

            // Obtenemos la secuencia Fibonacci desde la clase Fibonacci
            List<int> secuencia = Fibonacci.Generar(n);

            // Recorremos la secuencia y usamos la clase Primo para filtrar
            foreach (int numero in secuencia)
            {
                if (Primo.EsPrimo(numero))
                {
                    Console.Write(numero + " ");
                }
            }

            Console.WriteLine(); // Salto de línea final
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo válido.");
        }
    }
}

class Fibonacci // Generador de secuencia Fibonacci
{
    // Método estático que genera los primeros n términos de la secuencia Fibonacci
    public static List<int> Generar(int n)
    {
        List<int> secuencia = new List<int>();

        int a = 0, b = 1;

        for (int i = 0; i < n; i++)
        {
            if (i == 0)
                secuencia.Add(a);
            else if (i == 1)
                secuencia.Add(b);
            else
            {
                int siguiente = a + b;
                secuencia.Add(siguiente);
                a = b;
                b = siguiente;
            }
        }

        return secuencia;
    }
}

class Primo // Es primo? 
{
    // Método estático que devuelve true si el número es primo, false si no
    public static bool EsPrimo(int num)
    {
        if (num <= 1) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(num); i += 2)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}
