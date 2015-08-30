using System;
using System.Threading;

namespace FallingStrings2
{
    static class FallingString
    {
        private static Random rand = new Random();

        private static object lockIt = new object();

        public static void PrintString(object x)
        {
            int strLength = rand.Next(5, Console.WindowHeight - 10);
            int posX = (int)x;
            int posY = rand.Next(0, Console.WindowHeight - 2);
            int currentY;

            for (int i = 0; i < strLength; i++)
            {
                lock (lockIt)
                {
                    if (posY == Console.WindowHeight - 1)
                    {
                        posY = 0;
                        Console.SetCursorPosition(posX, posY);
                        currentY = posY + 1;
                    }
                    else
                    {
                        Console.SetCursorPosition(posX, posY++);
                        currentY = posY + 1;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Convert.ToChar(rand.Next(100, 126)));

                    if (currentY > 3 && i >= 2)
                    {
                        Console.SetCursorPosition(posX, currentY - 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Convert.ToChar(rand.Next(100, 126)));

                        Console.SetCursorPosition(posX, currentY - 4);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Convert.ToChar(rand.Next(100, 126)));
                    }
                    else if (currentY <= 2)
                    {
                        Console.SetCursorPosition(posX, currentY - 4 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Convert.ToChar(rand.Next(100, 126)));

                        Console.SetCursorPosition(posX, currentY - 5 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Convert.ToChar(rand.Next(100, 126)));
                    }

                    if (i == strLength - 1)
                    {
                        if (posY >= strLength)
                        {
                            Console.SetCursorPosition(posX, posY - strLength);
                            Console.WriteLine(' ');
                            i--;
                        }
                        else
                        {
                            Console.SetCursorPosition(posX, Console.WindowHeight - strLength + posY);
                            Console.WriteLine(' ');
                            i--;
                        }
                    }
                    Thread.Sleep(0);
                }
            }
        }
    }
}
