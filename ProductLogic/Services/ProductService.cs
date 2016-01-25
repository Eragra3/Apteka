using ProductLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLogic.Models;
using DAL.Interfaces;
using DAL.Factory;
using Logging;
using Logging.Interfaces;

namespace ProductLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkFactory _factory = new UnitOfWorkFactory();
        private readonly ILogger _logger = new Logger();

        public bool Add(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public ProductModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel>GetAllIngridients()
        {
            IList<ProductModel> models = null;
            using (var uow = _factory.Create())
            {
                try
                {
                    var entities = uow.ProductRepository.Get(e => e.IsIngridient);

                    if (entities == null) return null;

                    models = entities.Select(e => new ProductModel(e)).ToList();

                    uow.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(e);
                }
            }
            return models;
        }

        public bool Remove(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
