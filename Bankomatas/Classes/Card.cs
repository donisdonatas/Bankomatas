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
        private string _cardGuid;
        public string CardGuid
        {
            get{ return _cardGuid; } 
            set { _cardGuid = value; }
        }
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
                List<string> Guids = SQLite.GetFullColumn(SQLite.GuidTable, "GUID");
                foreach (string guid in Guids)
                {
                    if(Card == guid)
                    {
                        CardGuid = guid;
                        isCardValid = Card == guid;
                    }
                }
                if(!isCardValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Įdėta netinkama kortelė.");
                }
            } while (!isCardValid);
            return isCardValid;
        }

        public bool CheckPIN()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string getEncodedPinFromSQL = SQLite.GetPin(CardGuid);
                string pin = Encode.DecodedToString(getEncodedPinFromSQL);
                Console.WriteLine(getEncodedPinFromSQL + " / " + pin);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
                Pin = PIN.InputPIN();
                Console.WriteLine("Pin: " + Pin);
                string EncodedPin = Encode.EncodeToString(Pin);
                Console.WriteLine("EncodedPin: " + EncodedPin);
                string DecodedPin = Encode.DecodedToString(EncodedPin);
                Console.WriteLine("DecodedPin: " + DecodedPin);

                if (Pin == pin)
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
