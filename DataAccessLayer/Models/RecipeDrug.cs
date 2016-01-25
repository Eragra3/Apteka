using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RecipeDrug
    {
        public int ID { get; set; }

        public int EvaluatedByID { get; set; }

        public virtual Employee EvaluatedBy { get; set; }

        public int MadeByID { get; set; }

        public virtual Employee MadeBy { get; set; }

        public DateTime EvaluatedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
