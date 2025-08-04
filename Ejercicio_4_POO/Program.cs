using System;

namespace OOP_Recorderis_MessageApp
{
    internal class Program //MessageManager
    {
        static void Main()
        {
            AbstractSample simple = new SimplePrinter("Hola Mundo");
            AbstractSample fancy = new FancyPrinter("Hola Mundo");

            simple.PrintMessage("Hola Mundo");
            fancy.PrintMessage("Hola Mundo");

            Console.WriteLine("Invertido (simple): " + simple.InvertMessage("Hola Mundo"));
            Console.WriteLine("Invertido (fancy): " + fancy.InvertMessage("Hola Mundo"));
        }
    }
}
