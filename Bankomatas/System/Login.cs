using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankomatas.System
{
    public class Login
    {
        public static void LoginAnimation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for(var i = 0; i <= 100; i++)
            {
                if(i % 5 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    ClearCurrentConsoleLine();
                    Thread.Sleep(100);
                    Console.Write($"{i}%");
                }
            }
            Console.Write(" Prisijungta prie sąskaitos.");
            Thread.Sleep(1500);
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
