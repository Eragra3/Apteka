using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int PackageID { get; set; }

        public virtual Package Package { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        public decimal Price { get; set; }

        public int StatusID { get; set; }

        public virtual OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual IList<Contains> ProductList { get; set; }
    }
}
