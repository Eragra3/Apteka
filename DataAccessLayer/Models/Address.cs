﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Address
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }
    }
}
