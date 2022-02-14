using AppSqlite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppSqlite.Data
{
    class Migrate
    {
        public static bool DropTable()
        {
            var conn = new SQLiteConnection("transaction.db");
            string sql = "DROP TABLE IF EXISTS PersonalTransaction;";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;

        }
        public static bool CreateTables()
        {

            var conn = new SQLiteConnection("transaction.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                        PersonalTransaction (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                        Name VARCHAR( 140 ),
                        Description TEXT,
                        Detail TEXT,
                        Amount DOUBLE,
                        CreatedDate DATE,
                        Category INT
                        );";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public static bool MigrationData()
        {
            DropTable();
            CreateTables();
            var conn = new SQLiteConnection("transaction.db");
            var sqlInsert = "INSERT INTO PersonalTransaction(Name, Description, Detail, Amount, CreatedDate, Category) VALUES" +
            "('Dai', 'Chuyen tien', 'Tien mua rau', 10000, '2022-01-10', 1)," +
            "('Vuong', 'Chuyen tien', 'Tien mua dien thoai', 5000000, '2022-01-11', 1)," +
            "('Tho', 'Chuyen tien', 'Tien mua Laptop', 15000000, '2022-01-11', 1)," +
            "('SpringHung', 'Chuyen tien', 'Tien qua mon', 5000000, '2022-01-12', 1);";

            using (var pT = conn.Prepare(sqlInsert))
            {
                pT.Step();
            }
            return true;
        }
        public static bool SaveTables(Transaction personal)
        {
            var conn = new SQLiteConnection("transaction.db");
            using (var personalTransaction = conn.Prepare("INSERT INTO PersonalTransaction(Name, Description, Detail, Amount, CreatedDate, Category) VALUES (?, ?, ?, ?, ?, ?)"))
            {
                personalTransaction.Bind(1, personal.Name);
                personalTransaction.Bind(2, personal.Description);
                personalTransaction.Bind(3, personal.Detail);
                personalTransaction.Bind(4, personal.Amount);
                personalTransaction.Bind(5, personal.CreatedDate.ToString("yyyy-MM-dd"));
                personalTransaction.Bind(6, personal.Category);
                personalTransaction.Step();
            }
            return true;
        }

        public static List<Transaction> FindAll()
        {
            List<Transaction> list = new List<Transaction>();
            var conn = new SQLiteConnection("transaction.db");
            using (var personalTransaction = conn.Prepare("select * from PersonalTransaction"))
            {

                while (personalTransaction.Step() == SQLiteResult.ROW)
                {

                    Transaction personal = new Transaction()
                    {
                        Name = (string)personalTransaction["Name"],
                        Description = (string)personalTransaction["Description"],
                        Detail = (string)personalTransaction["Detail"],
                        Amount = (double)personalTransaction["Amount"],
                        CreatedDate = Convert.ToDateTime(personalTransaction["CreatedDate"]),
                    };
                    var category = (Int64)personalTransaction["Category"];
                    personal.Category = (int)category;
                    list.Add(personal);
                }
                return list;
            }
        }

        public static List<Transaction> ListTransactionByStartDateAndEndDate(string startDate, string endDate)
        {

            var list = new List<Transaction>();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("transaction.db");
                var sqlString = $"select * from PersonalTransaction where CreatedDate between '{startDate}' and '{endDate}'";
                using (var stt = cnn.Prepare(sqlString))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var personal = new Transaction()
                        {
                            Name = (string)stt["Name"],
                            Detail = (string)stt["Detail"],
                            Description = (string)stt["Description"],
                            Amount = Convert.ToDouble(stt["Amount"]),
                            CreatedDate = Convert.ToDateTime(stt["CreatedDate"]),
                            Category = Convert.ToInt32(stt["Category"]),
                        };
                       
                        list.Add(personal);
                    }
                }
                //Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Co loi list" + ex);
                return null;
            }
        }

        public static List<Transaction> getTransactionByCategory(int categoryId)
        {
            var list = new List<Transaction>();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("transaction.db");
                using (var stt = cnn.Prepare($"select * from PersonalTransaction where Category = {categoryId}"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var transaction = new Transaction()
                        {
                            Name = (string)stt["Name"],
                            Detail = (string)stt["Detail"],
                            Description = (string)stt["Description"],
                            Amount = Convert.ToDouble(stt["Amount"]),
                            CreatedDate = Convert.ToDateTime(stt["CreatedDate"]),
                            Category = Convert.ToInt32(stt["Category"]),
                        };
                        list.Add(transaction);
                    }
                }
                //Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail: " + ex);
                return null;
            }
        }

        public static List<Transaction> getTransactionByName(string name)
        {
            var list = new List<Transaction>();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("transaction.db");
                using (var stt = cnn.Prepare($"select * from PersonalTransaction where Name Like '%{name}%'"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var transaction = new Transaction()
                        {
                            Name = (string)stt["Name"],
                            Detail = (string)stt["Detail"],
                            Description = (string)stt["Description"],
                            Amount = Convert.ToDouble(stt["Amount"]),
                            CreatedDate = Convert.ToDateTime(stt["CreatedDate"]),
                            Category = Convert.ToInt32(stt["Category"]),
                        };
                        list.Add(transaction);
                    }
                }
                //Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Fail: " + ex);
                return null;
            }
        }
    }
}
