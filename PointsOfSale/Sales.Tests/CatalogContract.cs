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
            var price = new ProductPriceInfo(500.0);

            IEditableCatalog catalog = CreateCatalog();
            catalog.AddPriceWithoutPst("12345", 500.0);

            Assert.IsTrue(catalog.HasBarcode("12345"));
            Assert.AreEqual(price, catalog["12345"]);
        }

        [Test]
        public void ProductNotFound()
        {
            IEditableCatalog catalog = CreateCatalog();
            catalog.AddPriceWithoutPst("12345", 500.0);

            Assert.IsFalse(catalog.HasBarcode("23456"));
        }

        [Test]
        public void ProductWithPstFound()
        {
            var price = new ProductPriceInfo(100.00) { PstIncluded = true };

            IEditableCatalog catalog = CreateCatalog();

            catalog.AddPriceWithPst("23456", 100.00);
            Assert.IsTrue(catalog.HasBarcode("23456"));
            Assert.AreEqual(price, catalog["23456"]);
        }

        public abstract IEditableCatalog CreateCatalog();
    }
}
