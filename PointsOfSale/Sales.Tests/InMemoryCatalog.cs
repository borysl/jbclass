using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class InMemoryCatalogTests : CatalogContract
    {
        public override ICatalog CatalogWith(string s, double d)
        {
            var catalog = new Catalog();
            return catalog;
        }
    }
}
