using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Bankomatas.System
{
    public static class DefaultDatabase
    {
        public static void CreateTransactionsTypesTable()
        {
            using (SQLiteConnection ConnectionToDatabase = SQLite.CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='{SQLite.TransactionTypes}';";
                bool isTableExist = Convert.ToBoolean(SQLCommand.ExecuteScalar());
                if (!isTableExist)
                {
                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.TransactionTypes} (" +
                                                            $"TransactionTypeID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"TransactionType TEXT);";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.TransactionTypes} (" +
                                                            $"TransactionType) " +
                                                            $"VALUES (" +
                                                                    $"'Deposit');";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.TransactionTypes} (" +
                                                                    $"TransactionType) " +
                                                                    $"VALUES (" +
                                                                            $"'Withdrawal');";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.TransactionTypes} (" +
                                                                    $"TransactionType) " +
                                                                    $"VALUES (" +
                                                                            $"'Transfer');";
                    SQLCommand.ExecuteNonQuery();
                }
            }
        }

        public static void CreateGuidTable()
        {
            using (SQLiteConnection ConnectionToDatabase = SQLite.CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='{SQLite.GuidTable}';";
                bool isTableExist = Convert.ToBoolean(SQLCommand.ExecuteScalar());

                if(!isTableExist) 
                {
                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.GuidTable} (" +
                                                            $"CardID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"GUID CHARACTER(36));";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.GuidTable} (" +
                                                            $"GUID) " +
                                                            $"VALUES (" +
                                                                    $"'{Guid.NewGuid()}');";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.GuidTable} (" +
                                                            $"GUID) " +
                                                            $"VALUES (" +
                                                                    $"'{Guid.NewGuid()}');";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.GuidTable} (" +
                                                            $"GUID) " +
                                                            $"VALUES (" +
                                                                    $"'{Guid.NewGuid()}');";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.GuidTable} (" +
                                                            $"GUID) " +
                                                            $"VALUES (" +
                                                                    $"'{Guid.NewGuid()}');";
                    SQLCommand.ExecuteNonQuery();
                }
            }
        }

        public static void CreateClientsAccountsTable()
        {
            using (SQLiteConnection ConnectionToDatabase = SQLite.CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='{SQLite.ClientsAccounts}';";
                bool isTableExist = Convert.ToBoolean(SQLCommand.ExecuteScalar());

                if (!isTableExist)
                {
                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.ClientsAccounts} (" +
                                                            $"AccountID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"CardID INTEGER, " +
                                                            $"ClientID INTEGER, " +
                                                            $"CardPinEncoded CHARACTER(4), " +
                                                            $"CardBalance DECIMAL(10, 2));";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsAccounts} (" +
                                                            $"CardID, ClientID, CardPinEncoded, CardBalance) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"1, " +
                                                                    $"'{Encode.EncodeToString(PIN.GeneratePin())}', " +
                                                                    $"9654.47)";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsAccounts} (" +
                                                            $"CardID, ClientID, CardPinEncoded, CardBalance) " +
                                                            $"VALUES (" +
                                                                    $"2, " +
                                                                    $"2, " +
                                                                    $"'{Encode.EncodeToString(PIN.GeneratePin())}', " +
                                                                    $"1025.36)";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsAccounts} (" +
                                                            $"CardID, ClientID, CardPinEncoded, CardBalance) " +
                                                            $"VALUES (" +
                                                                    $"3, " +
                                                                    $"3, " +
                                                                    $"'{Encode.EncodeToString(PIN.GeneratePin())}', " +
                                                                    $"703.58)";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsAccounts} (" +
                                                            $"CardID, ClientID, CardPinEncoded, CardBalance) " +
                                                            $"VALUES (" +
                                                                    $"4, " +
                                                                    $"3, " +
                                                                    $"'{Encode.EncodeToString(PIN.GeneratePin())}', " +
                                                                    $"17896.59)";
                    SQLCommand.ExecuteNonQuery();
                }
            }
        }

        public static void CreateClientsInfoTable()
        {
            using (SQLiteConnection ConnectionToDatabase = SQLite.CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='{SQLite.ClientsInfo}';";
                bool isTableExist = Convert.ToBoolean(SQLCommand.ExecuteScalar());

                if (!isTableExist)
                {
                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.ClientsInfo} (" +
                                                            $"ClientID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"FirstName TEXT, " +
                                                            $"LastName TEXT, " +
                                                            $"Address TEXT, " +
                                                            $"Phone INTEGER);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsInfo} (" +
                                                            $"FirstName, LastName, Address, Phone) " +
                                                            $"VALUES (" +
                                                                    $"'Jonas', " +
                                                                    $"'Rimkus', " +
                                                                    $"'Kaunas', " +
                                                                    $"866611111);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsInfo} (" +
                                                            $"FirstName, LastName, Address, Phone) " +
                                                            $"VALUES (" +
                                                                    $"'Darius', " +
                                                                    $"'Kazlauskas', " +
                                                                    $"'Vilnius', " +
                                                                    $"866622222);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsInfo} (" +
                                                            $"FirstName, LastName, Address, Phone) " +
                                                            $"VALUES (" +
                                                                    $"'Paulius', " +
                                                                    $"'Urbonas', " +
                                                                    $"'Panevėžys', " +
                                                                    $"866633333);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsInfo} (" +
                                                            $"FirstName, LastName, Address, Phone) " +
                                                            $"VALUES (" +
                                                                    $"'Saulius', " +
                                                                    $"'ankauskas', " +
                                                                    $"'Kaunas', " +
                                                                    $"866644444);";
                    SQLCommand.ExecuteNonQuery();
                }
            }
        }

        public static void CreateClientsTransactionsTable()
        {
            using (SQLiteConnection ConnectionToDatabase = SQLite.CreateConnection())
            using (SQLiteCommand SQLCommand = ConnectionToDatabase.CreateCommand())
            {
                SQLCommand.CommandText = $"SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='{SQLite.ClientsTransactions}';";
                bool isTableExist = Convert.ToBoolean(SQLCommand.ExecuteScalar());

                if (!isTableExist)
                {
                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.ClientsTransactions} (" +
                                                            $"TransactionID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"CardID INTEGER, " +
                                                            $"TransactionDate DATETIME, " +
                                                            $"TransactionTypeID INTEGER, " +
                                                            $"TransactionDescr TEXT, " +
                                                            $"TransactionValue DECIMAL(10, 2));";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (" +
                                                            $"CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"'2023-01-09', " +
                                                                    $"2, " +
                                                                    $"'Pinigų išėmimas bankomate', " +
                                                                    $"100.00);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (" +
                                                            $"CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"'2023-01-09', " +
                                                                    $"2, " +
                                                                    $"'Pinigų išėmimas bankomate', " +
                                                                    $"50.00);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (" +
                                                            $"CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"'2023-01-09', " +
                                                                    $"2, " +
                                                                    $"'Išlaidos pirkiniams', " +
                                                                    $"6345.00);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (" +
                                                            $"CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"'2023-01-09', " +
                                                                    $"2, " +
                                                                    $"'Išlaidos pirkiniams', " +
                                                                    $"25.00);";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (" +
                                                            $"CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) " +
                                                            $"VALUES (" +
                                                                    $"1, " +
                                                                    $"'2023-01-09', " +
                                                                    $"1, " +
                                                                    $"'Atlyginimas', " +
                                                                    $"1896.78);";
                    SQLCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
