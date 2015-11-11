using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CurrencyConverter
    {
        public const string DKK = "DKK", EUR = "EUR", USD = "USD";
        private static double EURfactor = 7.46021948, USDfactor = 6.85871056;

        public static double ConvertPrice(double price, string currency)
        {
            switch (currency)
            {
                case EUR:
                    return convert(price, EURfactor);
                case USD:
                    return convert(price, USDfactor);
                default:
                    return price;
            }
        }

        private static double convert(double price, double conversionFactor)
        {
            return Math.Round(price/conversionFactor,2);
        }
    }
}
