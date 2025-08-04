using System;

namespace OOP_Recorderis_MessageApp
{
    abstract class AbstractSample
    {
        private string message;

        public AbstractSample(string msg)
        {
            message = msg;
        }

        protected string GetMessage()
        {
            return message;
        }

        public abstract void PrintMessage(string input);

        public virtual string InvertMessage(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}