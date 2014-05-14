using System;

namespace SimpleVM
{
    public interface IOutput
    {
        void Write(byte b);
    }

    public class Output : IOutput
    {
        public void Write(byte b)
        {
            Console.Write((char)b);
        }
    }
}