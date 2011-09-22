using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class CashRegisterDisplayTests
    {
        private CashRegisterDisplay _cashRegisterDisplay;

        [SetUp]
        public void Initialize()
        {
            _cashRegisterDisplay = new CashRegisterDisplay();
        }

        [Test]
        public void DisplayPriceWithoutPst()
        {
            var priceWithoutPst = new ProductPriceInfo(500.0);

            _cashRegisterDisplay.DisplayProductInfo(priceWithoutPst);

            Assert.AreEqual("EUR 500.00 G\nTotal: EUR 525.00", _cashRegisterDisplay.Display, "The price of 12345 should be 500.00 with total price");
        }

        [Test]
        public void DisplayPriceWithPst()
        {
            var priceWithoutPst = new ProductPriceInfo(100.0)
                                      {
                                          PstIncluded = true,
                                      };

            _cashRegisterDisplay.DisplayProductInfo(priceWithoutPst);

            Assert.AreEqual("EUR 100.00 GP\nTotal: EUR 115.50", _cashRegisterDisplay.Display, "The price of 12345 should be 500.00 with total price");
        }
    }
}
