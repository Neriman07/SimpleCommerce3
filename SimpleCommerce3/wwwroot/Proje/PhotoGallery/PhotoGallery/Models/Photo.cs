using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGallery.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
    }
}
