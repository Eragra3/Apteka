using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLogic.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public bool InOffer { get; set; }

        public bool IsIngridient { get; set; }

        public ProductModel()
        {

        }

        public ProductModel(Product entity)
        {
            ID = entity.ID;
            Price = entity.Price;
            Name = entity.Name;
            InOffer = entity.InOffer;
            IsIngridient = entity.IsIngridient;
        }

        public Product ToEntity()
        {
            var entity = new Product
            {
                ID = ID,
                IsIngridient = IsIngridient,
                InOffer = InOffer,
                Name = Name,
                Price = Price
            };
            return entity;
        }
    }

}
