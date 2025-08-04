using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la cantidad de segundos: ");
        string entrada = Console.ReadLine();
        int segundos;

        if (int.TryParse(entrada, out segundos) && segundos >= 0)
        {
            string resultado = ConvertirASegundosFormato(segundos);
            Console.WriteLine("Formato HH:MM:SS: " + resultado);
        }
        else
        {
            Console.WriteLine("Por favor, ingrese un número entero no negativo.");
        }
    }

    static string ConvertirASegundosFormato(int totalSegundos)
    {
        int horas = totalSegundos / 3600;
        int minutos = (totalSegundos % 3600) / 60;
        int segundos = totalSegundos % 60;

        return $"{horas:D2}:{minutos:D2}:{segundos:D2}";
    }
}
