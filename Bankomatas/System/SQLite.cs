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
        public static string GuidTableName = "GuidTable";
        public static string GuidTable = "Guid";
        public static string ClientsAccounts = "ClientsAccounts";
        public static string ClientsInfo = "ClientsInfo";
        public static string TransactionTypes = "TransactionTypes";
        public static string ClientsTransactions = "ClientsTransactions";
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

        public static void CreateGuidTable(SQLiteConnection conn)
        {
            SQLiteCommand SQLiteComm;
            string SQLiteCreate = $"CREATE TABLE {GuidTableName}(GUID CHARACTER(36));";
            SQLiteComm = conn.CreateCommand();
            SQLiteComm.CommandText = SQLiteCreate;
            SQLiteComm.ExecuteNonQuery();
        }

        public static void CreateClientsAccountsTable(SQLiteConnection conn)
        {
            SQLiteCommand SQLiteComm;
            string SQLiteCreate = $"CREATE TABLE {ClientsAccounts}(ClientID INTEGER PRIMARY KEY AUTOINCREMENT, GUID CHARACTER(36), CardID CHARACTER(4), CardBalance DECIMAL(10, 2));";
            SQLiteComm = conn.CreateCommand();
            SQLiteComm.CommandText = SQLiteCreate;
            SQLiteComm.ExecuteNonQuery();
        }

        public static void InsertDataToClientsAccountsTable(SQLiteConnection connection)
        {
            SQLiteCommand SQLiteComm;
            SQLiteComm = connection.CreateCommand();
            SQLiteComm.CommandText = $"INSERT INTO {ClientsAccounts}(GUID, CardID, CardBalance) VALUES ('{NewGuidString}', 1234, 5412.54)";
            SQLiteComm.ExecuteNonQuery();
            connection.Close();
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

        public static string GetGuid(SQLiteConnection conn)
        {
            SQLiteDataReader SQLiteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = $"SELECT GUID FROM {GuidTableName} WHERE GUID='d47f53e6-65b6-463e-8fbd-054c17390818';";
            SQLiteReader = sqliteCommand.ExecuteReader();
            string GuidString = null;
            while (SQLiteReader.Read())
            {
                GuidString = SQLiteReader.GetString(0);
            }
            Console.WriteLine($"GuidString from DB: {GuidString}");
            conn.Close();
            return GuidString;
        }
        public static string GetPin(SQLiteConnection conn)
        {
            SQLiteDataReader SQLiteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = $"SELECT CardID FROM {ClientsAccounts} WHERE GUID='0b7fff40-d4b9-4adf-a6f7-18eabdb033d5';";
            SQLiteReader = sqliteCommand.ExecuteReader();
            string PinFromDatabase = null;
            while (SQLiteReader.Read())
            {
                PinFromDatabase = SQLiteReader.GetString(0);
            }
            Console.WriteLine($"PinFromDatabase from DB: {PinFromDatabase}");
            conn.Close();
            return PinFromDatabase;
        }

        public static SQLiteDataReader GetFullColumn(string tableName, string columnName)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLiteDataReader SQLiteReader;
                SQLCommand.CommandText = $"SELECT {columnName} FROM {tableName};";
                SQLiteReader = SQLCommand.ExecuteReader();
                return SQLiteReader;
            }
        }
    }
}
