using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqlite_demo.Entity
{
    class Transaction
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Category { get; set; }


        public override string ToString()
        {
            return String.Format($"{Name} - {Detail} - {Description} - {Amount} - {CreatedDate.ToString("yyyy-MM-dd")} - {Category}");
        }
    }
}
