using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankomatas
{
    public static class Menu
    {
        public static void PrimaryMenu()
        {
            int LoginAttemps = 0;
            bool isLoginOK = false;
            string Pin = "";

            //Reikia daryti atskirus Metodus
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            Console.WriteLine("Įdėkite kortelę:");
            Console.ForegroundColor = ConsoleColor.White;
            //Galima padaryti Card Class, kuri iškvies įvedimą inicijuojant ir paskui turės metodą patikrinti atitikmenį. Tas pats ir su PIN.
            string Card = Console.ReadLine();
            bool isCardOK = true;

            while (LoginAttemps < 3 && !isLoginOK)
            {
                
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
                Pin = PIN.InputPIN();
                bool isPinOK = false;

                if(isCardOK && isPinOK)
                {
                    isLoginOK = true;
                }
                else
                {
                    LoginAttemps++;
                    if (LoginAttemps == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("3 kartus blogai įvestas slaptažodis.");
                        Console.WriteLine("Kortelė užblokuota");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Blogai įvestas slaptažodis. Bandykite dar kartą.");
                    Console.WriteLine("Liko bandymų {0}", 3 - LoginAttemps);
                }
            }
            Console.WriteLine(Pin);
        }
    }
}
