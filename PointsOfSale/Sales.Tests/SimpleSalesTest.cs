using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class SimpleSalesTest
    {
        private SalesPoint _salesPoint;
        private Scanner _scanner;
        private CashRegisterDisplay _cashRegisterDisplay;

        [SetUp]
        public void InitializeScanningSystem()
        {
            _scanner = new Scanner();
            _cashRegisterDisplay = new CashRegisterDisplay();
            var catalog = new Catalog();
            catalog.AddProductInfo("12345", 500.00);
            catalog.AddProductInfo("23456", 750.00);

            _salesPoint = new SalesPoint(catalog, _scanner, _cashRegisterDisplay);
        }

        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            _scanner.OnBarcode("12345");
            Assert.AreEqual("EUR 500.00 G\nTotal: EUR 525.00", _cashRegisterDisplay.Display, "The price of 12345 should be 500.00 with total price");
        }

        [Test]
        public void AnotherArticleWithDifferentPriceInEuros()
        {
            _scanner.OnBarcode("23456");
            Assert.AreEqual("EUR 750.00 G\nTotal: EUR 787.50", _cashRegisterDisplay.Display, "The price of 23456 should be 750.00 with total price 787.50");
        }

        [Test]
        public void EmptyBarcodeOutputsError()
        {
            _scanner.OnBarcode(string.Empty);
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
            _scanner.OnBarcode("999999");
            Assert.AreEqual("No product found: 999999.", _cashRegisterDisplay.Display);
        }
    }
}
