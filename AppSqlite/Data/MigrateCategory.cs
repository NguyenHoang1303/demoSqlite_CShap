using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSqlite.Data
{
    class MigrateCategory
    {
        public static void CreatedCategory()
        {
            var cnn = new SQLiteConnection("transaction.db");
            string sqlDropCategoryTransaction = @"DROP TABLE IF EXISTS Category;";
            using (var statement = cnn.Prepare(sqlDropCategoryTransaction))
            {
                statement.Step();
            }

            string sqlCategoryTransaction = @"CREATE TABLE IF NOT EXISTS
            Category (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
            Name VARCHAR( 140 )
            );
            ";

            using (ISQLiteStatement statement = cnn.Prepare(sqlCategoryTransaction))
            {
                statement.Step();
            }

            string sqlInsert = @"INSERT INTO Category(Name) VALUES ('Tien Bao Ke'),('Tien Di Choi'),('Tien Qua Mon'),('Tien An')";

            using (var create = cnn.Prepare(sqlInsert))
            {
             
                create.Step();
            }
        }
    }
}
