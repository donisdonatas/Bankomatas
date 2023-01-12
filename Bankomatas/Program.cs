using Bankomatas.System;
using System;
using System.Collections.Generic;

namespace Bankomatas
{
    internal class Program
    {
        static void Main()
        {
            DefaultDatabase.CreateDefaultDatabase();

            Console.ForegroundColor = ConsoleColor.Blue;
            List<string> Guids = SQLite.GetFullColumn(SQLite.GuidTable, "GUID");
            foreach(string guid in Guids)
            {
                Console.WriteLine(guid);
            }
            Menu.PrimaryMenu();
            Login.LoginAnimation();
            Menu.SecondaryMenu();
        }
    }
}
