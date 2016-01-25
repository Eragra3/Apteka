using Apteka.Models;
using ClientLogic.Models;
using ProductLogic.Interfaces;
using ProductLogic.Services;
using RecipeDrugLogic.Interfaces;
using RecipeDrugLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apteka.Controllers
{
    [Authorize]
    public class RecipeDrugController : Controller
    {
        private readonly IProductService _productService = new ProductService();
        private readonly IRecipeDrugService _recipeDrugService = new RecipeDrugService();

        private const decimal makingRecipeDrugPrice = 10M;

        [HttpGet]
        public ActionResult Index()
        {
            var models = _productService.GetAllIngridients();

            var model = new PrimaryRecipeDrugViewModel()
            {
                RecipeDrugViewModel = new RecipeDrugViewModel(),
                Ingridients = models
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PrimaryRecipeDrugViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Session["User"] as UserModel;
                model.RecipeDrugViewModel.Address = user.Address;
                return Payment(model.RecipeDrugViewModel);
            }
            var models = _productService.GetAllIngridients();
            model.Ingridients = models;

            return View(model);
        }

        [HttpPost]
        public ActionResult Payment(RecipeDrugViewModel model)
        {
            model.Ingridients = model.Ingridients.Where(i => !string.IsNullOrEmpty(i.Product)).ToList();

            var ingridients = _productService.GetAllIngridients();

            var ingPrice = 0M;
            foreach (var ing in model.Ingridients)
            {
                ing.Price = ing.Quantity * 0.001M * ingridients.First(i => i.Name.Equals(ing.Product)).Price;
                ingPrice += ing.Price.Value;
            }

            var newModel = new RecipeDrugPaymentViewModel()
            {
                RecipeDrug = model,
                IngPrice = ingPrice,
                ServicePrice = makingRecipeDrugPrice,
                ShippingPrice = Enums.ShippingPrices.ShippingPrice(model.Shipping)
            };

            var logicModel = newModel.ToBusinessModel();
            logicModel.Package.Address = model.Address;

            _recipeDrugService.Add(logicModel);

            return View("Payment", newModel);
        }

        [HttpPost]
        public ActionResult Pay(RecipeDrugPaymentViewModel model)
        {
            Session["RecipeDrug"] = model;
            return View(model);
        }
    }
}