using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
