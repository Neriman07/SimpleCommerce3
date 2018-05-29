using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneProjesi.Models
{
    public class Book
    {
        public int Id{ get; set; }
        [Required]
        [StringLength (200)]
        [Display (Name ="kitap adı")]
        public string Baslik { get; set; }
        [StringLength(200)]
        [Display(Name = "yazar adı")]
        public string Yazar { get; set; }
        [Display(Name = "yayın yılı")]
        public int BasimYili { get; set; }
        public int BaskiSayisi { get; set; }
        [StringLength(200)]
        [Display(Name = "kategori")]
        public string Kategori { get; set; }
    }
}
