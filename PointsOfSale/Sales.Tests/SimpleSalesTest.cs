using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SimpleScanner;

namespace Sales.Tests
{
    [TestFixture]
    public class SimpleSalesTest
    {
        [Test]
        public void ArticleShouldGetPriceInEuros()
        {
            var salesPoint = new SalesPoint();
            var scanner = new Scanner();
            var screen = new Screen();
            salesPoint.PlugScanner(scanner);
            salesPoint.PlugLcdScreen(screen);
            salesPoint.Scan("12345");
            Assert.AreEqual("EUR 500.00", screen.Display);
        }
    }

    public class SalesPoint
    {
        public void PlugScanner(object scanner)
        {
            throw new NotImplementedException();
        }

        public void PlugLcdScreen(object screen)
        {
            throw new NotImplementedException();
        }

        public void Scan(string s)
        {
            
        }
    }
}
