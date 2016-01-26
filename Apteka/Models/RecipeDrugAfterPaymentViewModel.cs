using RecipeDrugLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class RecipeDrugAfterPaymentViewModel
    {
        public RecipeDrugModel RecipeDrug { get; set; }

        public string PaymentType { get; set; }
    }
}