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
        public RecipeDrugViewModel RecipeDrug { get; set; }

        public string PaymentType { get; set; }

        public decimal IngPrice { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal ServicePrice { get; set; }

        public RecipeDrugModel ToBusinessModel()
        {
            var m = new RecipeDrugModel()
            {
                CreatedDate = DateTime.Now,
                EvaluatedDate = null,
                ID = 0,
                MadeBy = null,
                MadeByID = null,
                Package = new PackageModel(),
                Ingridients = RecipeDrug.Ingridients.Select(x => x.ToBusinessModel()).ToList(),
                PackageID = 0,
                Status = Common.Enums.OrderStatusEnum.NotPaid
            };

            return m;
        }
    }
}