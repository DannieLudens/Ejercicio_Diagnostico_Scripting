using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Valor apostado $1000 ahora ingrese el número apostado (4 cifras): ");
        string numeroApostado = Console.ReadLine();

        Console.Write("Ingrese el número ganador (4 cifras): ");
        string numeroGanador = Console.ReadLine();

        int ganancia = Chance.DeterminarGanancia(numeroApostado, numeroGanador);

        if (ganancia > 0)
        {
            Console.WriteLine("¡Felicidades! Ganaste $" + ganancia);
        }
        else
        {
            Console.WriteLine("No ganaste esta vez. ¡Sigue intentando!");
        }
    }
}

class Chance
{
    public static int DeterminarGanancia(string apostado, string ganador)
    {
        int valorApuesta = 1000;
        int ganancia = 0;

        if (apostado == ganador)
        {
            ganancia = valorApuesta * 4500;
        }
        else if (EsDesordenado(apostado, ganador))
        {
            ganancia = valorApuesta * 200;
        }
        else if (apostado.Substring(1) == ganador.Substring(1))
        {
            ganancia = valorApuesta * 400;
        }
        else if (apostado.Substring(2) == ganador.Substring(2))
        {
            ganancia = valorApuesta * 50;
        }
        else if (apostado[3] == ganador[3])
        {
            ganancia = valorApuesta * 5;
        }

        return ganancia;
    }

    private static bool EsDesordenado(string a, string b)
    {
        return a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
    }
}
