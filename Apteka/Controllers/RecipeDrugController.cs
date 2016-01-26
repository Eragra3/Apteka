using Apteka.Attributes;
using Apteka.Models;
using ClientLogic.Models;
using Common.Enums;
using ProductLogic.Interfaces;
using ProductLogic.Services;
using RecipeDrugLogic.Interfaces;
using RecipeDrugLogic.Models;
using RecipeDrugLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apteka.Controllers
{
    [CustomAuthorize]
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

                var recipeDrug = model.RecipeDrugViewModel;

                recipeDrug.Address = user.Address;
                recipeDrug.Ingridients = recipeDrug.Ingridients.Where(i => i.ProductID.HasValue).ToList();

                var ingridients = _productService.GetAllIngridients();

                var ingPrice = 0M;
                foreach (var ing in recipeDrug.Ingridients)
                {
                    ing.Price = ing.Quantity * 0.01M * ingridients.First(i => i.ID == ing.ProductID).Price;
                    ingPrice += ing.Price.Value;
                }

                var businessModel = model.RecipeDrugViewModel.ToBusinessModel();

                businessModel.Package.Price = ingPrice + makingRecipeDrugPrice + Common.Enums.ShippingPrices.ShippingPrice(recipeDrug.Shipping);
                businessModel.EvaluatedDate = DateTime.Now;

                var insertedID = _recipeDrugService.Add(businessModel);

                return Payment(insertedID.Value);
            }
            var models = _productService.GetAllIngridients();
            model.Ingridients = models;

            return View(model);
        }

        [HttpGet]
        public ActionResult Payment(int id)
        {
            var model = _recipeDrugService.Get(id);

            var viewModel = new RecipeDrugPaymentViewModel
            {
                IngPrice = model.Ingridients.Sum(i => i.Price),
                ServicePrice = makingRecipeDrugPrice,
                ShippingPrice = ShippingPrices.ShippingPrice(model.Package.Shipping),
                RecipeDrug = model
            };

            return View("Payment", viewModel);
        }

        [HttpPost]
        public ActionResult Payment(RecipeDrugPaymentViewModel model)
        {
            model.RecipeDrug = _recipeDrugService.Get(model.RecipeDrug.ID);

            var m = new RecipeDrugAfterPaymentViewModel
            {
                PaymentType = model.PaymentType,
                RecipeDrug = model.RecipeDrug
            };

            if (model.PaymentType.ToLower().Equals("ondelivery"))
            {
                model.RecipeDrug.Status = OrderStatusEnum.OnDelivery;
                return View("Success");
            }
            return PaymentPlaceholder(m);
        }

        [HttpPost]
        private ActionResult PaymentPlaceholder(RecipeDrugAfterPaymentViewModel model)
        {
            Session["RecipeDrug"] = model.RecipeDrug;
            return View("PaymentPlaceholder", model);
        }

        [HttpGet]
        public ActionResult Success(int id)
        {
            var model = _recipeDrugService.Get(id);

            model.Status = OrderStatusEnum.Paid;

            _recipeDrugService.Edit(model);

            return View("Success");
        }

        [HttpGet]
        public ActionResult Failure(int id)
        {
            return View("Failure", id);
        }
    }
}