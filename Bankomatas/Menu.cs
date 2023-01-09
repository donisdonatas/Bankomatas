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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            Card card = new Card();
            bool isCardValid = card.CheckCard();
            bool isPinValid = card.CheckPIN();
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
