using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class InMemoryCatalogTests : CatalogContract
    {
        public override ICatalog CatalogWith(string barcode, double price)
        {
            var catalog = new Catalog();
            catalog.AddProductInfo(barcode, price);
            return catalog;
        }
    }
}
