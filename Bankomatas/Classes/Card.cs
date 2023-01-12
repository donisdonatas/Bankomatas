using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Bankomatas.Classes
{
    public class Card
    {
        private string _cardGuid;
        public string CardGuid
        {
            get => _cardGuid;
            set => _cardGuid = value;
        }
        private bool isCardValid = false;
        private bool isPinValid = false;
        private string Pin;
        private int LoginAttempts = 0;
        
        public string CheckCard()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įdėkite kortelę:");
                Console.ForegroundColor = ConsoleColor.White;
                CardGuid = Console.ReadLine();
                List<string> Guids = SQLite.GetFullColumn(SQLite.GuidTable, "GUID");
                foreach (string guid in Guids)
                {
                    if(CardGuid == guid)
                    {
                        CardGuid = guid;
                        isCardValid = CardGuid == guid;
                    }
                }
                if(!isCardValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Įdėta netinkama kortelė.");
                }
            } while (!isCardValid);
            return CardGuid;
        }

        public void CheckPIN()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                string getEncodedPinFromSQL = SQLite.GetPin(CardGuid);
                string pin = Encode.DecodedToString(getEncodedPinFromSQL);
                Console.WriteLine(pin);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
                Pin = PIN.InputPIN();
                //string EncodedPin = Encode.EncodeToString(Pin);
                //string DecodedPin = Encode.DecodedToString(EncodedPin);

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
        }

        public void WithdrawMoney()
        {
            bool isWithdrawalValid = false;
            int WithdrawValue = 0;
            while (!isWithdrawalValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Įveskite sumą kurią norite išimti:");
                Exception err = null;
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    WithdrawValue = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Blogai įvesta suma. Pakartokite.");
                    err = ex;
                }
                finally
                {
                    if(err == null)
                    {
                        decimal CurrentBalance = SQLite.GetBalance(CardGuid);
                        int CountTransactions = SQLite.CountDailyTransactions(SQLite.GetCardID(CardGuid));
                        if(CountTransactions <= 10)
                        {
                            if (CurrentBalance >= (decimal)WithdrawValue)
                            {
                                if (WithdrawValue >= 10 && WithdrawValue <= 1000 && WithdrawValue % 10 == 0)
                                {
                                    SQLite.CreateWithdrawal(SQLite.GetCardID(CardGuid), WithdrawValue);
                                    SQLite.UpdateBalance(SQLite.GetCardID(CardGuid), (decimal)WithdrawValue);
                                    isWithdrawalValid = true;
                                }
                                else if (WithdrawValue > 1000)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Maksimali išduodama suma yra 1000Eur.");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Bankomatas gali išduoti tik apvaliom kupiūrom. Minimali išduodama suma 10Eur.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Jūsų balansas nepakankamas.");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Pasiekėte dienos operacijų skaičių");
                        }
                    }
                }
            }
        }
    }
}
