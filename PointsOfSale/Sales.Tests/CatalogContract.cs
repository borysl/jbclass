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
            var catalog = CatalogWith("12345", 500.0);
            Assert.IsTrue(catalog.HasBarcode("12345"));
            Assert.AreEqual(500.0, catalog["12345"]);
        }

        public abstract ICatalog CatalogWith(string s, double d);
    }
}
