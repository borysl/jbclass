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
            const double testPrice = 500.0;
            const string testBarcode = "12345";

            var mockScreenBuilder = new DynamicMock(typeof(IScreen));
            mockScreenBuilder.Expect("DisplayPrice", testPrice);

            var mockScreen = (IScreen)mockScreenBuilder.MockInstance;

            var mockCatalogBuilder = new DynamicMock(typeof(ICatalog));
            mockCatalogBuilder.ExpectAndReturn("get_Item", testPrice, testBarcode);
            mockCatalogBuilder.ExpectAndReturn("HasBarcode", true, testBarcode);

            var mockCatalog = (ICatalog)mockCatalogBuilder.MockInstance;

            var scanner = new Scanner();

            var salesPoint = new SalesPoint(mockCatalog, scanner, mockScreen);

            salesPoint.Scan(testBarcode);

            mockScreenBuilder.Verify();
            mockCatalogBuilder.Verify();
        }
    }
}
