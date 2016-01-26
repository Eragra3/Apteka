using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Enums
{
    public enum ShippingEnum
    {
        Courier = 1,
        InPost = 2,
        RegisteredLetter = 3
    }
    public class ShippingPrices
    {
        public static decimal ShippingPrice(ShippingEnum @enum)
        {
            switch (@enum)
            {
                case ShippingEnum.Courier:
                    return 10M;
                case ShippingEnum.InPost:
                    return 4M;
                case ShippingEnum.RegisteredLetter:
                    return 3.50M;
                default:
                    throw new Exception("No such shipping method!");
            }
        }
    }
}