using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class AddressModel
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public AddressModel()
        {

        }

        public AddressModel(Address entity)
        {
            City = entity.City;
            Street = entity.Street;
            ZipCode = entity.ZipCode;
            HouseNumber = entity.HouseNumber;
            ApartmentNumber = entity.ApartmentNumber;
        }

        public Address ToEntity()
        {
            var entity = new Address()
            {
                City = City,
                Street = Street,
                ZipCode = ZipCode,
                HouseNumber = HouseNumber,
                ApartmentNumber = ApartmentNumber
            };
            return entity;
        }
    }

}
