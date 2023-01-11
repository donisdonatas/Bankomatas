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

        public static string GetPin(string guid)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLiteDataReader SQLiteReader;
                SQLCommand.CommandText = $"SELECT CardPinEncoded FROM {ClientsAccounts} INNER JOIN {GuidTable} ON {ClientsAccounts}.AccountID = {GuidTable}.CardID WHERE {GuidTable}.GUID = '{guid}';";
                SQLiteReader = SQLCommand.ExecuteReader();
                string encodedPin = "";
                while (SQLiteReader.Read())
                {
                    encodedPin = SQLiteReader.GetString(0);
                }
                return encodedPin;
            }
        }

        public static List<string> GetFullColumn(string tableName, string columnName)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLiteDataReader SQLiteReader;
                SQLCommand.CommandText = $"SELECT {columnName} FROM {tableName};";
                SQLiteReader = SQLCommand.ExecuteReader();
                List<string> StringsList = new List<string>();
                while (SQLiteReader.Read())
                {
                    StringsList.Add(SQLiteReader.GetString(0));
                }
                return StringsList;
            }
        }

        public static decimal GetBalance(string guid)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT SUM(CardBalance) FROM {ClientsAccounts} INNER JOIN {GuidTable} ON {ClientsAccounts}.AccountID = {GuidTable}.CardID WHERE {GuidTable}.GUID = '{guid}';";
                decimal Balance = Convert.ToDecimal(SQLCommand.ExecuteScalar());
                return Balance;
            }
        }

        public static void GetLastTransactions(string guid, int number)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLiteDataReader SQLiteReader;
                SQLCommand.CommandText = $"SELECT TransactionDate, TransactionDescr, TransactionValue, TransactionType FROM {ClientsTransactions} " +
                                         $"INNER JOIN {GuidTable} ON {ClientsTransactions}.CardID = {GuidTable}.CardID " +
                                         $"INNER JOIN {TransactionTypes} ON {ClientsTransactions}.TransactionTypeID = {TransactionTypes}.TransactionTypeID " +
                                         $"WHERE {GuidTable}.GUID = '{guid}' AND {ClientsTransactions}.TransactionTypeID = 2 " +
                                         $"ORDER BY {ClientsTransactions}.TransactionID DESC " +
                                         $"LIMIT {number};";
                SQLiteReader = SQLCommand.ExecuteReader();
                
                while (SQLiteReader.Read())
                {
                    DateTime TrDate = Convert.ToDateTime(SQLiteReader[0]);
                    string TrDesc = Convert.ToString(SQLiteReader[1]);
                    decimal TrValue = Convert.ToDecimal(SQLiteReader[2]);
                    string TrType = Convert.ToString(SQLiteReader[3]);
                    Console.WriteLine($"{TrDate.ToString("yyyy.MM.dd")} {TrType}: {TrDesc} - {TrValue}Eur");
                }
            }
        }

        public static void CreateWithdrawal(int cardID, int value)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                SQLCommand.CommandText = $"INSERT INTO {ClientsTransactions} (CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                         $"VALUES ({cardID}, '{today}', 2, 'Pinigų išėmimas bankomate', {value});";
                SQLCommand.ExecuteNonQuery();
            }
        }

        public static int GetCardID(string guid)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT CardID FROM {GuidTable} WHERE GUID = '{guid}';";
                int cardID = Convert.ToInt32(SQLCommand.ExecuteScalar());
                return cardID;
            }
        }

        public static int CountDailyTransactions(int cardID)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(*) FROM {ClientsTransactions} WHERE CardID = {cardID} AND TransactionDate = '{DateTime.Today.ToString("yyyy-MM-dd")}';";
                int CountTransactions = Convert.ToInt32(SQLCommand.ExecuteScalar());
                return CountTransactions;
            }
        }

        public static void UpdateBalance(int cardID, decimal value)
        {
            using (SQLiteConnection ConnectionToDatabase = CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"UPDATE {ClientsAccounts} SET CardBalance = CardBalance - {value} WHERE CardID = {cardID};";
                SQLCommand.ExecuteNonQuery();
            }
        }
    }
}
