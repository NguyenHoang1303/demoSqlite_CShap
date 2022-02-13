using AppSqlite.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;

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
                        CreatedDate DATETIME,
                        Category INT
                        );";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public static bool DeleteData()
        {
            var conn = new SQLiteConnection("transaction.db");
            var sqlInsert = "DELETE FROM PersonalTransaction;";

            using (var pT = conn.Prepare(sqlInsert))
            {
                pT.Step();
            }
            return true;
        }

        public static bool MigrationData()
        {
            var conn = new SQLiteConnection("transaction.db");
            var sqlInsert = "INSERT INTO PersonalTransaction(Name, Description, Detail, Amount, CreatedDate, Category) VALUES"+
            "('Dai', 'Chuyen tien', 'Tien mua rau', 10000, '2022-1-10', 1)," +
            "('Vuong', 'Chuyen tien', 'Tien mua dien thoai', 5000000, '2022-1-11', 1)," +
            "('Tho', 'Chuyen tien', 'Tien mua Laptop', 15000000, '2022-1-11', 1)," +
            "('SpringHung', 'Chuyen tien', 'Tien qua mon', 5000000, '2022-1-12', 1);";
       
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
                        Amount = (double)personalTransaction["Amount"]
                    };
                    var date = (string)personalTransaction["CreatedDate"];
                    var category = (Int64)personalTransaction["Category"];
                    personal.CreatedDate = DateTime.Parse(date);
                    personal.Category = (int)category;
                    list.Add(personal);
                }
                return list;
            }
        }
    }
}
