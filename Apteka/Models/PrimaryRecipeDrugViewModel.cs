using ProductLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apteka.Models
{
    public class PrimaryRecipeDrugViewModel
    {
        public RecipeDrugViewModel RecipeDrugViewModel { get; set; }

        public IEnumerable<ProductModel> Ingridients { get; set; }
    }
}