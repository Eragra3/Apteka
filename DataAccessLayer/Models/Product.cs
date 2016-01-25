using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        public int ID { get; set; }

        public decimal Price { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public bool InOffer { get; set; }
    }
}
