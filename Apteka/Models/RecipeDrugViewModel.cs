using Common.Enums;
using Common.Models;
using PackageLogic.Models;
using RecipeDrugLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apteka.Models
{
    public class RecipeDrugViewModel
    {
        [Required(ErrorMessage = "Musisz dać nam znać jak przygotować ten lek.")]
        [Display(Name = "Przepis")]
        public string Recipe { get; set; }

        public AddressModel Address { get; set; }

        [Required(ErrorMessage = "Wybierz sposób dostawy.")]
        [Display(Name = "Sposób dostawy")]
        public ShippingEnum Shipping { get; set; }

        public IList<IngridientViewModel> Ingridients { get; set; }

        public RecipeDrugViewModel()
        {
            Ingridients = new List<IngridientViewModel>()
            {
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel()
            };
        }

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
                Ingridients = Ingridients.Select(x => x.ToBusinessModel()).ToList(),
                PackageID = 0,
                Status = Common.Enums.OrderStatusEnum.NotPaid
            };
            m.Package.Shipping = Shipping;
            m.Package.Address = Address;

            return m;
        }

        public void PrepareIngridients()
        {
            Ingridients = new List<IngridientViewModel>()
            {
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel(),
                new IngridientViewModel()
            };
        }
    }
}