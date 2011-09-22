using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public abstract class CatalogContract
    {
        [Test]
        public void ProductFound()
        {
            var price = new PriceWithTaxes(500.0);

            var catalog = CatalogWith("12345", 500.0);
            Assert.IsTrue(catalog.HasBarcode("12345"));
            Assert.AreEqual(price, catalog["12345"]);
        }

        public abstract ICatalog CatalogWith(string s, double d);
    }
}
