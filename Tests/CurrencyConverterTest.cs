using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using BLL;
using MovieStoreBE;

namespace Tests
{
    [TestFixture]
    public class CurrencyConverterTest
    {
        private double EURfactor = 7.46021948, USDfactor = 6.85871056;

        [Test]
        public void ConvertFromDKKtoEUR()
        {
            double price = 100;
            double convertedPrice = CurrencyConverter.ConvertPrice(price, CurrencyConverter.EUR);

            double expectedConversion = Math.Round(price / EURfactor, 2);

            Assert.AreEqual(expectedConversion, convertedPrice);
        }

        [Test]
        public void ConvertFromDKKtoUSD()
        {
            double price = 100;
            double convertedPrice = CurrencyConverter.ConvertPrice(price, CurrencyConverter.USD);

            double expectedConversion = Math.Round(price / USDfactor, 2);

            Assert.AreEqual(expectedConversion, convertedPrice);
        }

        [Test]
        public void ConvertNegative()
        {
            double price = -100;
            double convertedPrice = CurrencyConverter.ConvertPrice(price, CurrencyConverter.USD);

            double expectedConversion = Math.Round(price / USDfactor, 2);

            Assert.AreEqual(expectedConversion, convertedPrice);
        }

        [Test]
        public void ConvertZero()
        {
            double price = 0;
            double convertedPrice = CurrencyConverter.ConvertPrice(price, CurrencyConverter.USD);

            double expectedConversion = Math.Round(price / USDfactor, 2);

            Assert.AreEqual(expectedConversion, convertedPrice);
        }
    }
}
