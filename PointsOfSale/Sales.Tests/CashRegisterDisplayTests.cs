using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class CashRegisterDisplayTests
    {
        private CashRegisterDisplay _cashRegisterDisplay;

        [Test]
        public void DisplayPriceWithoutPst()
        {
            var priceWithoutPst = new PriceWithTaxes(500.0);

            _cashRegisterDisplay = new CashRegisterDisplay();

            _cashRegisterDisplay.DisplayProductInfo(priceWithoutPst);

            Assert.AreEqual("EUR 500.00 G\nTotal: EUR 525.00", _cashRegisterDisplay.Display, "The price of 12345 should be 500.00 with total price");
        }
    }
}
