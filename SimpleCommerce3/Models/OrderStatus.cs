using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce3.Models
{
    public enum OrderStatus // Sipariş Durumu
    {
        WaitingPaymentApproval=1,
        paymentAproved=2,
        PreparingForDeliveriy=3,
        OnShipping=4,
        DeliverySucces=5
    }
}
