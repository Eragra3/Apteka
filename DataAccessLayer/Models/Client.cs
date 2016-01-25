using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }

        public string NIP { get; set; }

        public Address Address { get; set; }
    }
}
