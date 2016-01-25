using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manager
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public int StatusID { get; set; }

        public ManagerStatus Status { get; set; }
    }
}
