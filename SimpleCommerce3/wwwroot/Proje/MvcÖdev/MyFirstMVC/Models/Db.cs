using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMVC.Models
{
    public interface IDb
    {
        IList<Day> Days { get; set; }
    }
    public class Db:IDb
    {

        public IList<Day> Days { get; set; }
        public Db()
        {
            Days = new List<Day>();
           

        }
    }
}
