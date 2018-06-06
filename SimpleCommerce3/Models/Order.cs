using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Order // Sipariş
    {
        public Order()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        [StringLength(200)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Sahibi")]
        
        public string Owner { get; set; }
        [Display(Name = "Sepet")]
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        [Display(Name = "Sepet")]
        public Cart Cart { get; set; }
        [Display(Name = "Müşteri")]
        [ForeignKey("CustomerId")]
     
        public int? CustomerId { get; set; }
        [Display(Name = "Müşteri ")]
        public Customer Customer { get; set; }
        [Display(Name = "Sipariş Durumu ")]
        public OrderStatus OrderStatus { get; set; }
        [Display(Name = "Teslimat Notları")]
        [StringLength(4000)]
        public string ShippingNotes { get; set; }

    }
}
