using System;

namespace OOP_Recorderis_MessageApp
{
    class FancyPrinter : AbstractSample
    {
        public FancyPrinter(string msg) : base(msg) { }

        public override void PrintMessage(string input)
        {
            string convertido = "";

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                    convertido += char.ToLower(c);
                else if (char.IsLower(c))
                    convertido += char.ToUpper(c);
                else
                    convertido += c;
            }

            Console.WriteLine("Mensaje con cambio de mayúsculas/minúsculas: " + convertido);
        }

        public override string InvertMessage(string input)
        {
            string invertido = base.InvertMessage(input);
            string resultado = "";

            foreach (char c in invertido)
            {
                if (char.IsUpper(c))
                    resultado += char.ToLower(c);
                else if (char.IsLower(c))
                    resultado += char.ToUpper(c);
                else
                    resultado += c;
            }

            return resultado;
        }
    }
}