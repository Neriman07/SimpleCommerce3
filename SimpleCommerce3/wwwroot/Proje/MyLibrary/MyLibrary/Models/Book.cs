using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Kitap Adı")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name = "Yazar")]
        public string Author { get; set; }
        [Display(Name = "Yayın Yılı")]
        public int PublishYear { get; set; }
        [StringLength(200)]
        [Display(Name = "Kategori")]
        public string Category { get; set; }
    }
}
