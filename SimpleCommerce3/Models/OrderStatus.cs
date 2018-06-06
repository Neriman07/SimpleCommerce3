using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public enum OrderStatus // Sipariş Durumu
    {
        [Display(Name = "Ödeme Bekleniyor")]
        WaitingPaymentApproval =1,
        [Display(Name = "Ödeme Onaylandı")]
        paymentAproved =2,
        [Display(Name = "Kargo için Hazırlanıyor")]
        PreparingForDeliveriy =3,
        [Display(Name = "Kargo")]
        OnShipping =4,
        [Display(Name = "Teslimat Başarılı")]
        DeliverySucces =5

    }
}
