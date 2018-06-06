using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public class Customer // Müşteri
    {
        public int Id { get; set; }
        [Display(Name ="Fatura Adı")]
        [StringLength(200)]
        public string BillingFirstName { get; set; }

        [Display(Name = "Fatura Soyadı")]
        [StringLength(200)]
        public string BillingLastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return BillingFirstName + " " + BillingLastName;
            }
        }

        [Display(Name = "Fatura Kimlik No")]
        [StringLength(200)]
        public string BillingIdentityName { get; set; }
        [Display(Name = "Fatura şirket Adı")]
        [StringLength(200)]
        public string BillingCompanyName { get; set; }
        [Display(Name = "Fatura Ülke")]
        [StringLength(200)]
        public string BillingCountry { get; set; }
        [Display(Name = "Fatura Şehir")]
        [StringLength(200)]
        public string BillingCity { get; set; }
        [Display(Name = "Fatura Mahale/semt")]
        [StringLength(200)]
        public string BillingDistrict { get; set; }
        [Display(Name = "Fatura Cade")]
        [StringLength(200)]
        public string BillingStreet { get; set; }
        [Display(Name = "Fatura İlçe")]
        [StringLength(200)]
        public string BillingCounty { get; set; }
        [Display(Name = "Fatura Adres")]
        [StringLength(200)]
        public string BillingAddress { get; set; }
        [Display(Name = "Fatura Posta kodu")]
        [StringLength(200)]
        public string BillingZipCode { get; set; }
        [Display(Name = "Fatura e-posta")]
        [StringLength(200)]
        public string BillingEmail { get; set; }
        [Display(Name = "Fatura Telefon")]
        [StringLength(200)]
        public string BillingPhone { get; set; }

        [Display(Name = "Teslimat Adı ")]
        [StringLength(200)]
        public string ShipingFirstName { get; set; }
        [Display(Name = "Teslimat Soyadı")]
        [StringLength(200)]
        public string ShipingLastName { get; set; }
        [Display(Name = "Teslimat Kimlik no")]
        [StringLength(200)]
        public string ShipingIdentityName { get; set; }
        [Display(Name = "Teslimat Şirket Adı")]
        [StringLength(200)]
        public string ShipingCompanyName { get; set; }
        [Display(Name = "Teslimat Ülke ")]
        [StringLength(200)]
        public string ShipingCountry { get; set; }
        [Display(Name = "Teslimat Şehir ")]
        [StringLength(200)]
        public string ShipingCity { get; set; }
        [Display(Name = "Teslimat Mahalle/semt ")]
        [StringLength(200)]
        public string ShipingDistrict { get; set; }
        [Display(Name = "Teslimat Cadde")]
        [StringLength(200)]
        public string ShipingStreet { get; set; }
        [Display(Name = "Teslimat ilçe ")]
        [StringLength(200)]
        public string ShipingCounty { get; set; }
        [Display(Name = "Teslimat adres ")]
        [StringLength(200)]
        public string ShipingAddress { get; set; }
        [Display(Name = "Teslimat posta kodu")]
        [StringLength(200)]
        public string ShipingZipCode { get; set; }
        [Display(Name = "Teslimat  E-posta ")]
        [StringLength(200)]
        public string ShipingEmail { get; set; }
        [Display(Name = "Teslimat telefon")]
        [StringLength(200)]
        public string ShipingPhone { get; set; }

        public string UserName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
