using Common.Enums;
using Common.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageLogic.Models
{
    public class PackageModel
    {
        public int ID { get; set; }

        public decimal Price { get; set; }

        public AddressModel Address { get; set; }

        public DateTime? AssemblyDate { get; set; }

        public PackageModel()
        {

        }

        public PackageModel(Package model)
        {
            if (model != null)
            {
                ID = model.ID;
                Price = model.Price;
                Address = new AddressModel(model.Address);
                AssemblyDate = model.AssemblyDate;
            }
        }

        public Package ToEntity()
        {
            var entity = new Package()
            {
                ID = ID,
                Price = Price,
                Address = Address?.ToEntity(),
                AssemblyDate = AssemblyDate,
            };
            return entity;
        }
    }
}
