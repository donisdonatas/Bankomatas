using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Security;

namespace Bankomatas.System
{
    public static class SQLite
    {
        internal static string GuidTableName = "GuidTable";
        internal static string NewGuidString = Guid.NewGuid().ToString();
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection SQLiteConn = new SQLiteConnection("Data Source = bankomatas.db; Version = 3; New = True; Compress = True;");
            try
            {
                SQLiteConn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There was error connecting to database. Error code: {ex.Message}");
            }
            finally
            {
                //SQLiteConn.Close();
            }

            return SQLiteConn;
        }

        public static void CreteGuidTable(SQLiteConnection conn)
        {
            SQLiteCommand SQLiteComm;
            string SQLiteCreate = $"CREATE TABLE {GuidTableName}(GUID String(36));";
            SQLiteComm = conn.CreateCommand();
            SQLiteComm.CommandText = SQLiteCreate;
            SQLiteComm.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand SQLiteComm;
            SQLiteComm = conn.CreateCommand();
            SQLiteComm.CommandText = $"INSERT INTO {GuidTableName}(GUID) VALUES ('{NewGuidString}')";
            SQLiteComm.ExecuteNonQuery();
        }

        public static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader SQLiteReader;
            SQLiteCommand SQLiteComm;
            SQLiteComm = conn.CreateCommand();
            SQLiteComm.CommandText = $"SELECT * FROM {GuidTableName};";
            SQLiteReader = SQLiteComm.ExecuteReader();
            while(SQLiteReader.Read())
            {
                string ReadingString = SQLiteReader.GetString(0);
                Console.WriteLine(ReadingString);
            }

            conn.Close();   //Kodėl čia pavyzdyje uždaromas konnectionas? Gal reiktų jį įkelti į Try-Finish bloką
        }
    }
}
