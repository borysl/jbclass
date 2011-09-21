using System;
using NUnit.Framework;
using SimpleScanner;

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
            _salesPoint.PlugScanner(_scanner);
            _salesPoint.PlugLcdScreen(_screen);
        }

        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            _salesPoint.Scan("12345");
            Assert.AreEqual("EUR 500.00", _screen.Display);
        }

        //[Test]
        //public void EmptyBarcodeOutputsError()
        //{
        //    _salesPoint.Scan(string.Empty);
        //    Assert.AreEqual("Scan error: Empty barcode", _screen.Display);
        //}

        //[Test]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void NullBarcodeProducesException()
        //{
        //    _salesPoint.Scan(null);
        //}

        //[Test]
        //public void NotProductFoundOutputsError()
        //{
        //    _salesPoint.Scan("999999");
        //    Assert.AreEqual("No product found: 999999", _screen.Display);
        //}
    }
}
