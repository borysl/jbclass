using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class SimpleSalesTest
    {
        private SalesPoint _salesPoint;
        private CashRegisterDisplay _cashRegisterDisplay;

        [SetUp]
        public void InitializeScanningSystem()
        {
            _cashRegisterDisplay = new CashRegisterDisplay();
            IEditableCatalog catalog = new Catalog();
            catalog.AddPriceWithoutPst("12345", 500.00);
            catalog.AddPriceWithPst("23456", 750.00);

            _salesPoint = new SalesPoint(catalog, _cashRegisterDisplay);
        }

        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            _salesPoint.Scan("12345");
            Assert.AreEqual("EUR 500.00 G\nTotal: EUR 525.00", _cashRegisterDisplay.Display, "The price of 12345 should be 500.00 with total price");
        }

        [Test]
        public void AnotherArticleWithDifferentPriceInEuros()
        {
            _salesPoint.Scan("23456");
            Assert.AreEqual("EUR 750.00 GP\nTotal: EUR 866.25", _cashRegisterDisplay.Display, "The price of 23456 should be 750.00 with total price 787.50");
        }

        [Test]
        public void EmptyBarcodeOutputsError()
        {
            _salesPoint.Scan(string.Empty);
            Assert.AreEqual("Scan error: Empty barcode.", _cashRegisterDisplay.Display);
        }

        //[Test]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullBarcodeProducesException()
        //{
        //    _salesPoint.Scan(null);
        //}

        [Test]
        public void NotProductFoundOutputsError()
        {
            _salesPoint.Scan("999999");
            Assert.AreEqual("No product found: 999999.", _cashRegisterDisplay.Display);
        }
    }
}
