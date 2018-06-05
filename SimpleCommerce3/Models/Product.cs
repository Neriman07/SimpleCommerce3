using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Product
    {
        public Product()
        {
            CreateData = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [StringLength(200)]
        [Display(Name = "Resim")]
        public string Photo { get; set; } 
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }   
        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Kategori")]
        public Category Category{get; set;}
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime? CreateData { get; set; }

        [Display(Name = "Öne Çıkan Mı ?:")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Yayında Mı? :")]
        public bool IsPublished { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
