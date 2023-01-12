using Bankomatas.Classes;
using Bankomatas.System;
using System;
using System.Threading;

namespace Bankomatas
{
    public static class Menu
    {
        internal static Card card;
        internal static string CardGuid { get; set; }
        public static void PrimaryMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            card = new Card();
            CardGuid = card.CheckCard();
            card.CheckPIN();
        }

        public static int LoggedUserMenu()
        {
            bool isGoodChoise = false;
            int menuChoise = 0;
            
            while (!isGoodChoise)
            {
                Exception err = null;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sveiki prisijungę prie savo paskyros.");
                Console.WriteLine("Pasirinkite pageidaujamą operaciją:");
                Console.WriteLine("[1] Matyti einamajį balansą.");
                Console.WriteLine("[2] Paskutinės 5 atliktos opracijos.");
                Console.WriteLine("[3] Pinigų išėmimas.");
                Console.WriteLine("[0] Pasiimti kortelę. Ir uždaryti programą.");
                Console.ForegroundColor = ConsoleColor.White;
                isGoodChoise = false;
                try
                {
                    menuChoise = int.Parse(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pasirinkimo klaida. Klaidos pranešimas: {ex.Message}");
                    Console.WriteLine("Bandykite dar kartą.");
                    err = ex;
                    Thread.Sleep(3000);
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pasirinkimo klaida. Klaidos pranešimas: {ex.Message}");
                    Console.WriteLine("Bandykite dar kartą.");
                    err = ex;
                    Thread.Sleep(3000);
                }
                finally
                {
                    if(err == null)
                    {
                        isGoodChoise = true;
                    }
                }
            }
            return menuChoise;
        }

        public static void SecondaryMenu()
        {
            bool isGoodChoise = false;
            while (!isGoodChoise)
            {
                switch (LoggedUserMenu())
                {
                    case 1:
                        decimal Balance = SQLite.GetBalance(CardGuid);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Dabartinis balansas: {Balance}Eur.");
                        isGoodChoise = true;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Paskutinės 5 atliktos opracijos:");
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SQLite.GetLastTransactions(CardGuid, 5);
                        isGoodChoise = true;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Pinigų išėmimas");
                        card.WithdrawMoney();
                        isGoodChoise = true;
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Viso gero.");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        isGoodChoise = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Pasirinkimo klaida.");
                        Console.WriteLine("Bandykite dar kartą.");
                        Thread.Sleep(2000);
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Ar norite atlikti sekančią operaciją?");
                Console.WriteLine("[1] Taip");
                Console.WriteLine("[2] Ne");
                Console.ForegroundColor = ConsoleColor.White;
                Exception err = null;
                int nextOperation = 1;
                try
                {
                    nextOperation = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Blogai įvestas pasirinkimas.");
                    err = ex;
                }

                if(err == null && nextOperation == 1)
                {
                    isGoodChoise = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Viso gero.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
    }
}
