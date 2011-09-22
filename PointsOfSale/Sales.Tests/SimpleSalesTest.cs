﻿using NUnit.Framework;
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
            _scanner = new Scanner();
            _screen = new Screen();
            var catalog = new Catalog();
            catalog.AddProductInfo("12345", 500.00);
            catalog.AddProductInfo("23456", 750.00);

            _salesPoint = new SalesPoint(catalog, _scanner, _screen);
        }

        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            _scanner.OnBarcode("12345");
            Assert.AreEqual("EUR 500.00", _screen.Display, "The price of 12345 should be 500.00");
        }

        [Test]
        public void AnotherArticleWithDifferentPriceInEuros()
        {
            _scanner.OnBarcode("23456");
            Assert.AreEqual("EUR 750.00", _screen.Display, "The price of 234567 should be 750.00");
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
