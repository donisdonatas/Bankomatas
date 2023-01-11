using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Threading;

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


            Console.ReadLine();
        }
    }
}
