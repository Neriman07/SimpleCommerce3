using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthDaysApp.Models
{
    public interface IDb
    {
        IList<Friend> Friends { get; set; }
    }
    public class Db:IDb
    {
        public IList<Friend> Friends { get; set; }
        
        public Db()
        {
            Friends = new List<Friend>();
        }
    }
}
