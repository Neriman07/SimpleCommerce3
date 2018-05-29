using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneProjesi.Models
{
   
     public class Db : IDb//interface yi implament ettik
     {
            
           public IList<Book> Books { get; set; }
           public IList<Customers> Customers { get; set; }

            public Db()
            {
            //constracterda boş liste oluşturmamızın nedeni 
            //interfacenin hata vermemesi için boş liste ataması yapmak.

            Books = new List<Book>();
               Customers = new List<Customers>();
            }
        
       
     }
}
