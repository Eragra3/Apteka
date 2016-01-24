using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogic.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreationDate { get; set; }

        public string NIP { get; set; }

        public virtual AddressModel Address { get; set; }
    }
}
