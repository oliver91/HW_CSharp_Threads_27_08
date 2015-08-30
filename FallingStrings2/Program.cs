using System;
using System.Threading;

namespace FallingStrings2
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            for (int i = 0; i < Console.WindowWidth - 1; i += rand.Next(3))
            {
                new Thread(
                    new ParameterizedThreadStart(
                        FallingString.PrintString)).Start((object)i);
            }
        }
    }
}
