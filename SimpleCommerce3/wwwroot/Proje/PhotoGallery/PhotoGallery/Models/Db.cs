using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class Db:IDb
    {
        public IList<Photo> Photos { get; set; }
        public Db()
        {
            Photos = new List<Photo>();
        }
    }
}
