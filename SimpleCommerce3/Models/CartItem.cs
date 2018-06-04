using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }//sepete eklenen ürün hangi ürün

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } // navigasyon propertisi sepete eklenen ürüne uaşır
        public int Quantity { get; set; }
        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                return Product.Price*Quantity;
            }
        }
    }
}
