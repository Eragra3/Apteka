using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Package
    {
        public int ID { get; set; }

        public decimal Price { get; set; }

        public Address Address { get; set; }

        public DateTime? AssemblyDate { get; set; }

        public int ShippingID { get; set; }

        public virtual Shipping Shipping { get; set; }
    }
}
