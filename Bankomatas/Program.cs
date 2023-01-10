using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Bankomatas
{
    internal class Program
    {
        static void Main()
        {
            
            DefaultDatabase.CreateTransactionsTypesTable();
            DefaultDatabase.CreateGuidTable();
            DefaultDatabase.CreateClientsInfoTable();
            DefaultDatabase.CreateClientsAccountsTable();
            DefaultDatabase.CreateClientsTransactionsTable();

            Console.ForegroundColor = ConsoleColor.Blue;
            List<string> Guids = SQLite.GetFullColumn(SQLite.GuidTable, "GUID");
            foreach(string guid in Guids)
            {
                Console.WriteLine(guid);
            }

            //SQLiteConnection sqliteConnection;
            //sqliteConnection = SQLite.CreateConnection();
            //SQLite.CreateClientsAccountsTable(sqliteConnection);
            //SQLite.InsertDataToClientsAccountsTable(sqliteConnection);
            //SQLite.ReadData(sqliteConnection);

            Menu.PrimaryMenu();
            Login.LoginAnimation();
            Menu.LoggedUserMenu();


            Console.ReadLine();
        }
    }
}
