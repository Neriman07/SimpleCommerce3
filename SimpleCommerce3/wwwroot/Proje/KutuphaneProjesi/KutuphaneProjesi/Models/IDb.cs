using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneProjesi.Models
{
   public interface IDb
    {
        
            IList<Book> Books { get; set; }
            IList<Customers> Customers { get; set; }
        
    }
}
