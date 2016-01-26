using PackageLogic.Models;
using RecipeDrugLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class RecipeDrugPaymentViewModel
    {
        public RecipeDrugModel RecipeDrug { get; set; }

        public string PaymentType { get; set; }

        public decimal IngPrice { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal ServicePrice { get; set; }

        public decimal GetFullPrice()
        {
            return IngPrice + ServicePrice + ShippingPrice;
        }
    }
}