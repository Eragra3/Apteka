using DAL.Models;
using ProductLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDrugLogic.Models
{
    public class IngridientModel
    {
        public int ID { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int ProductID { get; set; }

        public ProductModel Product { get; set; }

        public IngridientModel()
        {
        }

        public IngridientModel(Ingridient entity)
        {
            ID = entity.ID;
            Quantity = entity.Quantity;
            Price = entity.Price;
            ProductID = entity.ProductID;
            Product = new ProductModel(entity.Product);
        }

        public Ingridient ToEntity()
        {
            var entity = new Ingridient
            {
                ID = ID,
                Quantity = Quantity,
                Price = Price,
                ProductID = ProductID,
                Product = Product?.ToEntity()
            };
            return entity;
        }
    }
}
