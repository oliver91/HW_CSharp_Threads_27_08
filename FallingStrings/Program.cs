using System;
using System.Threading;

namespace FallingStrings
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < Console.WindowWidth - 1; i += 2)
            {
                new Thread(
                    new ParameterizedThreadStart(
                        FallingString.PrintString)).Start((object)i);
            }
        }
    }
}
