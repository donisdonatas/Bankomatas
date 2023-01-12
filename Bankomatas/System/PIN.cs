using System;

namespace Bankomatas.System
{
    public static class PIN
    {
        public static string InputPIN()
        {
            string PIN = "";
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKeyInfo Keyboard = Console.ReadKey(true);
            while (Keyboard.Key != ConsoleKey.Enter & PIN.Length < 4)
            {
                if (Keyboard.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    PIN += Keyboard.KeyChar;
                }
                else if (Keyboard.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(PIN))
                    {
                        PIN = PIN.Substring(0, PIN.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Keyboard = Console.ReadKey(true);
            }
            Console.WriteLine();
            return PIN;
        }

        public static string GeneratePin()
        {
            string Pin = "";
            for(var i = 0; i < 4; i++)
            {
                Pin += RandomDigit.GetRandom().ToString();
            }
            return Pin;
        }
    }
}
