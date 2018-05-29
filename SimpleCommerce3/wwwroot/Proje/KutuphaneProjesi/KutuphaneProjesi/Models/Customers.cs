using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneProjesi.Models
{
    public class Customers
    {
        public Customers()
        {
            AldigiKitaplar = new List<Book>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Ad { get; set; }
        [Display(Name = "soyad")]
        public string Soyad { get; set; }
        [Display(Name = "üyelik tarihi")]
        public DateTime UyelikTarihi { get; set; }
        [Display(Name = "Aldığı kitaplar")]
        public IList<Book> AldigiKitaplar { get; set; }
    }
}
