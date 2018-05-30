using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Slide
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name =("Ad"))]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = ("Resim"))]
        public string Photo{ get; set; }
        [StringLength(200)]
        public string Url { get; set; }
        [Display(Name = ("Pozisyon"))]
        public int Position { get; set; }
        public bool IsPublished{ get; set; }
       

    }
}
