using ProductLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLogic.Interfaces
{
    public interface IProductService
    {
        ProductModel Get(int id);

        IList<ProductModel> GetAllIngridients();

        bool Add(ProductModel model);

        bool Remove(ProductModel model);

        bool Edit(ProductModel model);
    }
}
