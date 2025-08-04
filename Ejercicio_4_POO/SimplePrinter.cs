using System;

namespace OOP_Recorderis_MessageApp
{
    class SimplePrinter : AbstractSample
    {
        public SimplePrinter(string msg) : base(msg) { }

        public override void PrintMessage(string input)
        {
            Console.WriteLine("Mensaje original: " + input);
        }
    }
}