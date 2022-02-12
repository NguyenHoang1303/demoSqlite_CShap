using Sqlite_demo.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqlite_demo.Data
{
    class MigrateData
    {
        private DateTime date;

        public static bool CreateTables()
        {
            var conn = new SQLiteConnection("sqlitepcldemo.db");
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
        public static bool SaveTables(Transaction personal)
        {
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            using (var personalTransaction = conn.Prepare("INSERT INTO PersonalTransaction(Name, Description, Detail, Money, CreatedDate, Category) VALUES (?, ?, ?, ?, ?, ?)"))
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
            var conn = new SQLiteConnection("sqlitepcldemo.db");
            using (var personalTransaction = conn.Prepare("select * from PersonalTransaction"))
            {

                while (personalTransaction.Step() == SQLiteResult.ROW)
                {

                    Transaction personal = new Transaction()
                    {
                        Name = (string)personalTransaction["Name"],
                        Description = (string)personalTransaction["Description"],
                        Detail = (string)personalTransaction["Detail"],
                        Amount = (double)personalTransaction["Money"]
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
