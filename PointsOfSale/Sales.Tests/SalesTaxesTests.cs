using System;
using NUnit.Framework;

namespace Sales.Tests
{
    /// <summary>
    /// Try to do something with RhinoMocks
    /// </summary>
    [TestFixture]
    public class SalesTaxesTests
    {
        [Test]
        public void CalculateTaxesForSomethingPriced100Dollars()
        {
            var barcode = "12345";

            var taxCalculator = new TaxCalculator();

            Assert.AreEqual(25.0, taxCalculator.CalculateGST(barcode));
        }
    }

    public class TaxCalculator : ITaxCalculator
    {
        public double CalculateGST(string barcode)
        {
            return 25.0;
        }
    }

    public interface ITaxCalculator
    {
    }
}
