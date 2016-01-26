using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apteka.Helpers
{
    public class Translators
    {
        private const string courier = "courier";
        private const string inpost = "inpost";
        private const string registeredletter = "registeredletter";

        public static string ShippingTranslator(string s)
        {
            s = s.ToLower();
            switch (s)
            {
                case courier:
                    return "Kurier";
                case inpost:
                    return "Paczkomat InPost";
                case registeredletter:
                    return "List polecony";
                default:
                    throw new Exception("No such value as : " + s);
            }
        }
    }
}