using System;
using System.Threading;

namespace Bankomatas.System
{
    public class Login
    {
        public static void LoginAnimation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for(var i = 0; i <= 100; i++)
            {
                if(i % 10 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    ClearCurrentConsoleLine();
                    Console.Write($"{i}%");
                    Thread.Sleep(100);
                }
            }
            Console.Write(" Prisijungta prie sąskaitos.");
            Thread.Sleep(1000);
        }

        internal static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
