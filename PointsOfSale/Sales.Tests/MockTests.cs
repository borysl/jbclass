using NUnit.Framework;
using NUnit.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class MockTests
    {
        [Test]
        public void FoundProductShouldOutputPrice()
        {
            var mockScreenBuilder = new DynamicMock(typeof(IScreen));
            mockScreenBuilder.Expect("DisplayPrice", "EUR 500.00");

            var mockScreen = (IScreen)mockScreenBuilder.MockInstance;

            var mockCatalogBuilder = new DynamicMock(typeof(ICatalog));
            mockCatalogBuilder.ExpectAndReturn("get_Item", 500.0, "12345");
            mockCatalogBuilder.ExpectAndReturn("HasBarcode", true, "12345");

            var mockCatalog = (ICatalog)mockCatalogBuilder.MockInstance;

            var scanner = new Scanner();

            var salesPoint = new SalesPoint(mockCatalog, scanner, mockScreen);

            scanner.OnBarcode("12345");

            mockScreenBuilder.Verify();
            mockCatalogBuilder.Verify();
        }
    }
}
