using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BirthDaysApp.Models
{
    public class Friend
    {
        public int Id { get; set; }
        [StringLength (200, ErrorMessage ="{0} alanı maksimum {1} karakter olmalıdır")]
        [Required(ErrorMessage ="{0} alanı zorunludur.")]
        [Display(Name = "ad soyad")]
        public string Name { get; set; }
        [Required (ErrorMessage ="{0} alanı zorunludur")]
        [Display(Name = "dogum tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
     
       
    }
}
