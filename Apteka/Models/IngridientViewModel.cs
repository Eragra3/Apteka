using RecipeDrugLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class IngridientViewModel
    {
        [Display(Name = "Składnik")]
        public int? ProductID { get; set; }

        [Display(Name = "Ilość")]
        public decimal Quantity { get; set; }

        public decimal? Price { get; set; }

        public IngridientModel ToBusinessModel()
        {
            var model = new IngridientModel
            {
                ID = 0,
                Price = Price.Value,
                ProductID = ProductID.HasValue ? ProductID.Value : 0,
                Product = null,
                Quantity = Quantity
            };
            return model;
        }
    }
}