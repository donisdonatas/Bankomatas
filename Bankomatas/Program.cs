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

            SQLiteConnection sqliteConnection;
            sqliteConnection = SQLite.CreateConnection();
            SQLite.CreteGuidTable(sqliteConnection);
            SQLite.InsertData(sqliteConnection);
            SQLite.ReadData(sqliteConnection);

            Menu.PrimaryMenu();




            Console.ReadLine();
        }
    }
}
