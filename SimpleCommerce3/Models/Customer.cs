using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingIdentityName { get; set; }
        public string BillingCompanyName { get; set; }
        public string BillingCountry { get; set; }
        public string BillingDistrict { get; set; }
        public string BillingStreet { get; set; }
        public string BillingCounty { get; set; }
        public string BillingAddress { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }

        public string ShipingFirstName { get; set; }
        public string ShipingLastName { get; set; }
        public string ShipingIdentityName { get; set; }
        public string ShipingCompanyName { get; set; }
        public string ShipingCountry { get; set; }
        public string ShipingDistrict { get; set; }
        public string ShipingStreet { get; set; }
        public string ShipingCounty { get; set; }
        public string ShipingAddress { get; set; }
        public string ShipingZipCode { get; set; }
        public string ShipingEmail { get; set; }
        public string ShipingPhone { get; set; }

        public string UserName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
