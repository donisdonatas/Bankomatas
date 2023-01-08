using Bankomatas.Classes;
using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            //int LoginAttemps = 0;
            //bool isLoginOK = false;
            //string Pin = "";

            //Reikia daryti atskirus Metodus
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            //Console.WriteLine("Įdėkite kortelę:");
            //Console.ForegroundColor = ConsoleColor.White;
            ////Galima padaryti Card Class, kuri iškvies įvedimą inicijuojant ir paskui turės metodą patikrinti atitikmenį. Tas pats ir su PIN.
            //string Card = Console.ReadLine();
            //SQLiteConnection sqliteConnection = SQLite.CreateConnection();
            //string dbGuid = SQLite.GetGuid(sqliteConnection);
            Card card = new Card();
            bool isCardValid = card.CheckCard();
            bool isPinValid = card.CheckPIN();

            //bool isCardOK = (Card == dbGuid) ? true : false;    //Čia True / False galima nerašyti, nes palyginimas jau pats duoda True / False reikšmę
            // Badar dar reikia padaryti, kad patikrintų ar gerai įvestas GUIDas. Ir padaryti, kad suktų ciklą, jei negerai įvestas.

            //while (LoginAttemps < 3 && !isLoginOK)
            //{
            //    //Console.ForegroundColor = ConsoleColor.Green;
            //    //Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
            //    //Pin = PIN.InputPIN();
            //    bool isPinOK = true;

            //    if(isCardValid && isPinOK)
            //    {
            //        isLoginOK = true;
            //    }
            //    else
            //    {
            //        LoginAttemps++;
            //        if (LoginAttemps == 3)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine("3 kartus blogai įvestas slaptažodis.");
            //            Console.WriteLine("Kortelė užblokuota");
            //            Thread.Sleep(3000);
            //            Environment.Exit(0);
            //        }
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("Blogai įvestas slaptažodis. Bandykite dar kartą.");
            //        Console.WriteLine("Liko bandymų {0}", 3 - LoginAttemps);
            //    }
            //}
            //Console.WriteLine(Pin);
        }

        public static void LoggedUserMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki prisijungę prie savo paskyros.");
            Console.WriteLine("Pasirinkite pageidajamą operaciją:");
            Console.WriteLine("[1] Matyti einamajį balansą.");
            Console.WriteLine("[2] Paskutinės 5 atliktos opracijos.");
            Console.WriteLine("[3] Pinigų išėmimas.");
            Console.WriteLine("[0] Pasiimti kortelę. Ir uždaryti programą.");
        }
    }
}
