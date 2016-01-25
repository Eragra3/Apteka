using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ingridient
    {
        public int ID { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int RecipeDrugID { get; set; }

        public virtual RecipeDrug RecipeDrug { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
