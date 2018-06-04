using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Cart
    {
        public Cart()
        {
            // CartItems boş olmasın varsayılan bir değer olsun diye yaptık
            CartItems = new HashSet<CartItem>();
        }
        public int Id { get; set; }
        public string Owner{ get; set; }
       public virtual ICollection<CartItem> CartItems { get; set; }
        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(c=>c.TotalPrice);
            }
        }
    }
}
