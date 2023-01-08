using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankomatas.Classes
{
    public class Card
    {
        private bool isCardValid = false;
        private bool isPinValid = false;
        private string Pin;
        private int LoginAttempts = 0;
        public bool CheckCard()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įdėkite kortelę:");
                Console.ForegroundColor = ConsoleColor.White;
                string Card = Console.ReadLine();
                SQLiteConnection sqliteConnection = SQLite.CreateConnection();
                string dbGuid = SQLite.GetGuid(sqliteConnection);
                if(Card == dbGuid)
                {
                    isCardValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Įdėta netinkama kortelė.");
                    isCardValid = false;
                }
            } while (!isCardValid);
            return isCardValid;
        }

        public bool CheckPIN()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
                Pin = PIN.InputPIN();
                Console.WriteLine("Pin: " + Pin);
                string EncodedPin = Encode.EncodeToString(Pin);
                Console.WriteLine("EncodedPin: " + EncodedPin);
                string DecodedPin = Encode.DecodedToString(EncodedPin);
                Console.WriteLine("DecodedPin: " + DecodedPin);
                SQLiteConnection sqliteConnection = SQLite.CreateConnection();
                string PinFromDataBase = SQLite.GetPin(sqliteConnection);
                if (Pin == PinFromDataBase)
                {
                    isPinValid = true;
                }
                else
                {
                    LoginAttempts++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Blogai įvestas slaptažodis. Bandykite dar kartą.");
                    Console.WriteLine("Liko bandymų: {0}", 3 - LoginAttempts);
                }
            } while(!isPinValid && LoginAttempts < 3);

            if(LoginAttempts == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3 kartus blogai įvestas slaptažodis.");
                Console.WriteLine("Kortelė užblokuota.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }

            return isPinValid;
        }
    }
}
