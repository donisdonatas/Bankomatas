using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            Console.WriteLine("Įdėkite kortelę:");
            Console.ForegroundColor = ConsoleColor.White;
            string Card = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Įveskite keturių skaitmenų PIN kodą:");
            string Pin = PIN.InputPIN();
            
            Console.WriteLine(Pin);
            Console.ReadLine();
        }
    }
}
