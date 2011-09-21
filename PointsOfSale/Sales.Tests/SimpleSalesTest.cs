using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class SimpleSalesTest
    {
        private SalesPoint _salesPoint;
        private Scanner _scanner;
        private Screen _screen;

        [SetUp]
        public void InitializeScanningSystem()
        {
            _salesPoint = new SalesPoint();
            _scanner = new Scanner();
            _screen = new Screen();
            _salesPoint = new SalesPoint(_scanner, _screen);
        }

        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            _scanner.OnBarcode("12345");
            Assert.AreEqual("EUR 500.00", _screen.Display, "The price of 12345 should be 500.00");
        }

        [Test]
        public void EmptyBarcodeOutputsError()
        {
            _scanner.OnBarcode(string.Empty);
            Assert.AreEqual("Scan error: Empty barcode.", _screen.Display);
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
            Assert.AreEqual("No product found: 999999.", _screen.Display);
        }
    }
}
