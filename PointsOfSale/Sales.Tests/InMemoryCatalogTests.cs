using NUnit.Framework;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class InMemoryCatalogTests : CatalogContract
    {
        public override IEditableCatalog CreateCatalog()
        {
            var catalog = new Catalog();
            return catalog;
        }
    }
}
