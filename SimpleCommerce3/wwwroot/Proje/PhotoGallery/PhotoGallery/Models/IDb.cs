using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public interface IDb
    {
        IList<Photo> Photos { get; set; }
    }
}
