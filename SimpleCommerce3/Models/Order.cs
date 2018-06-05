using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Order
    {
        public Order()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Owner { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
