using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [StringLength(200)]
        public string LastName { get; set; }
        [Display(Name = "Üyelik Tarihi")]
        public DateTime MembershipDate { get; set; }
        [Display(Name = "Aldığı Kitaplar")]
        public IList<Book> RecievedBooks { get; set; }

        public Customer()
        {
            RecievedBooks = new List<Book>();
        }
    }
}
