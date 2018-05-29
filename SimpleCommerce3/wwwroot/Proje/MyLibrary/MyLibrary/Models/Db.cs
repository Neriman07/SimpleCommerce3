using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Db:IDb
    {
        public IList<Book> Books { get; set; }
        public IList<Customer> Customers { get; set; }

        public Db()
        {
            Books = new List<Book>();
            Customers = new List<Customer>();
        }
    }
}
