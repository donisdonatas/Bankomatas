using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
                                                                    $"'income');";
                    SQLCommand.ExecuteNonQuery();

                    SQLCommand.CommandText = $"INSERT INTO {SQLite.TransactionTypes} (" +
                                                                    $"TransactionType) " +
                                                                    $"VALUES (" +
                                                                            $"'expense');";
                    SQLCommand.ExecuteNonQuery();
                    SQLCommand.CommandText = $"INSERT INTO {SQLite.TransactionTypes} (" +
                                                                    $"TransactionType) " +
                                                                    $"VALUES (" +
                                                                            $"'transfer');";
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
                    List<string> SQLCommandsValues = new List<string>() {
                        "1, '2023-01-04', 2, 'Pinigų išėmimas bankomate', 100.00",
                        "1, '2023-01-04', 2, 'Pirkimas', 10.46",
                        "1, '2023-01-05', 2, 'Pirkimas', 9.42",
                        "1, '2023-01-05', 2, 'Sąskaita', 120.00",
                        "1, '2023-01-06', 2, 'Pinigų išėmimas bankomate', 50.00",
                        "1, '2023-01-06', 2, 'Pirkimas internetu', 12.36",
                        "1, '2023-01-09', 2, 'Pirkimas', 47.59",
                        "1, '2023-01-09', 2, 'Pirkimas', 27.69",
                        "1, '2023-01-09', 2, 'Pirkimas', 8.12",
                        "1, '2023-01-09', 2, 'Pirkimas', 147.00",
                        "1, '2023-01-09', 2, 'Pirkimas', 241.00",
                        "1, '2023-01-09', 2, 'Pirkimas', 17.99",
                        "1, '2023-01-09', 2, 'Pirkimas', 65.00",
                        "1, '2023-01-10', 1, 'Atlyginimas', 1896.27",
                        "1, '2023-01-10', 2, 'Pirkimas', 247.15",
                        "1, '2023-01-10', 2, 'Pirkimas', 100.15",
                        "2, '2023-01-04', 2, 'Pirkimas', 97.15",
                        "2, '2023-01-04', 2, 'Pirkimas', 13.56",
                        "2, '2023-01-05', 2, 'Pirkimas', 87.58",
                        "2, '2023-01-05', 2, 'Pinigų išėmimas bankomate', 47.99",
                        "2, '2023-01-05', 1, 'Atlyginimas', 97.15",
                        "2, '2023-01-07', 2, 'Pinigų išėmimas bankomate', 200.00",
                        "2, '2023-01-09', 2, 'Pirkimas', 42.17",
                        "2, '2023-01-09', 2, 'Pirkimas', 56.36",
                        "2, '2023-01-09', 2, 'Pirkimas', 78.89",
                        "2, '2023-01-09', 2, 'Pirkimas', 14.25",
                        "2, '2023-01-09', 2, 'Pirkimas', 78.95",
                        "2, '2023-01-09', 2, 'Pirkimas', 12.45",
                        "2, '2023-01-09', 2, 'Pirkimas', 25.78",
                        "2, '2023-01-09', 2, 'Pirkimas', 38.74",
                        "2, '2023-01-10', 2, 'Pirkimas', 14.45",
                        "2, '2023-01-10', 2, 'Pirkimas', 77.88",
                        "2, '2023-01-10', 2, 'Pinigų išėmimas bankomate', 100.00",
                        "2, '2023-01-10', 2, 'Pirkimas', 46.78",
                        "3, '2023-01-08', 2, 'Pirkimas', 9.25",
                        "3, '2023-01-08', 2, 'Pirkimas', 19.47",
                        "3, '2023-01-09', 2, 'Pirkimas', 25.69",
                        "3, '2023-01-09', 2, 'Pirkimas', 46.36",
                        "3, '2023-01-09', 2, 'Pirkimas', 78.65",
                        "3, '2023-01-09', 2, 'Pirkimas', 5.45",
                        "3, '2023-01-09', 2, 'Pirkimas', 36.58",
                        "3, '2023-01-09', 2, 'Pirkimas', 74.82",
                        "3, '2023-01-09', 2, 'Pirkimas', 75.65",
                        "3, '2023-01-09', 2, 'Pirkimas', 14.45",
                        "3, '2023-01-09', 2, 'Pirkimas', 5.57",
                        "3, '2023-01-09', 2, 'Pirkimas', 16.15",
                        "3, '2023-01-10', 2, 'Pirkimas', 19.45",
                        "3, '2023-01-10', 2, 'Pirkimas', 25.65",
                        "3, '2023-01-10', 2, 'Pirkimas', 35.74",
                        "3, '2023-01-10', 2, 'Pirkimas', 75.39",
                        "3, '2023-01-10', 2, 'Pirkimas', 41.78",
                        "3, '2023-01-10', 2, 'Pirkimas', 45.91",
                        "3, '2023-01-10', 2, 'Pirkimas', 51.73",
                        "3, '2023-01-10', 2, 'Pirkimas', 36.19",
                        "3, '2023-01-10', 2, 'Pirkimas', 89.98",
                        "3, '2023-01-10', 2, 'Pirkimas', 25.75",
                        "3, '2023-01-11', 2, 'Pirkimas', 36.65",
                        "3, '2023-01-11', 2, 'Pirkimas', 77.42",
                        "3, '2023-01-11', 2, 'Pirkimas', 99.76",
                        "3, '2023-01-11', 2, 'Pirkimas', 9.86",

                    };

                    SQLCommand.CommandText = $"CREATE TABLE {SQLite.ClientsTransactions} (" +
                                                            $"TransactionID INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                            $"CardID INTEGER, " +
                                                            $"TransactionDate DATETIME, " +
                                                            $"TransactionTypeID INTEGER, " +
                                                            $"TransactionDescr TEXT, " +
                                                            $"TransactionValue DECIMAL(10, 2));";
                    SQLCommand.ExecuteNonQuery();
					foreach(string valueLine in SQLCommandsValues)
					{
						SQLCommand.CommandText = $"INSERT INTO {SQLite.ClientsTransactions} (CardID, TransactionDate, TransactionTypeID, TransactionDescr, TransactionValue) VALUES ({valueLine});";
						SQLCommand.ExecuteNonQuery();
					}
                }
            }
        }

        public static void CreateDefaultDatabase()
        {
            CreateTransactionsTypesTable();
            CreateGuidTable();
            CreateClientsInfoTable();
            CreateClientsAccountsTable();
            CreateClientsTransactionsTable();
        }
    }
}
