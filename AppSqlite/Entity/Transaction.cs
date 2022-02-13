using System;

namespace AppSqlite.Entity
{
    class Transaction
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Category { get; set; }
    }
}
