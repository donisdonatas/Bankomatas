using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        // remove one character from the list of password characters
                        PIN = PIN.Substring(0, PIN.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Keyboard = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
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

        public static char EncryptPIN(char c, int salt)
        {
            {
                int PinDigit;
                PinDigit = (int)c + salt;
                if (PinDigit > (int)'z')
                {
                    PinDigit -= (int)'z';
                }
                char r = (char)PinDigit;
                return r;
            }
        }
    }
}
