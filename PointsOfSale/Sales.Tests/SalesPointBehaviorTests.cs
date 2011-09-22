using NUnit.Framework;
using NUnit.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class SalesPointBehaviorTests
    {
        private DynamicMock _mockScreenBuilder;
        private DynamicMock _mockCatalogBuilder;

        [SetUp]
        public void Initialize()
        {
            _mockScreenBuilder = new DynamicMock(typeof(IScreen));
            _mockCatalogBuilder = new DynamicMock(typeof(ICatalog));
        }

        [TearDown]
        public void Verify()
        {
            _mockScreenBuilder.Verify();
            _mockCatalogBuilder.Verify();
        }

        [Test]
        public void FoundProductShouldOutputPrice()
        {
            var testPrice = new PriceWithTaxes
                                           {
                                               NetPrice = 500.0,
                                               PstIncluded = false,
                                           };

            const string testBarcode = "12345";

            _mockScreenBuilder.Expect("DisplayProductInfo", testPrice);

            var mockScreen = (IScreen)_mockScreenBuilder.MockInstance;

            _mockCatalogBuilder.ExpectAndReturn("get_Item", testPrice, testBarcode);
            _mockCatalogBuilder.ExpectAndReturn("HasBarcode", true, testBarcode);

            var mockCatalog = (ICatalog)_mockCatalogBuilder.MockInstance;

            var scanner = new Scanner();

            var salesPoint = new SalesPoint(mockCatalog, scanner, mockScreen);

            salesPoint.Scan(testBarcode);
        }

        [Test]
        public void NoGoodFoundReturnsError()
        {
            const string testBarcode = "12345";

            _mockScreenBuilder.ExpectNoCall("DisplayProductInfo");
            _mockScreenBuilder.Expect("DisplayProductNotFound", testBarcode);

            var mockScreen = (IScreen)_mockScreenBuilder.MockInstance;

            _mockCatalogBuilder.ExpectNoCall("get_Item");
            _mockCatalogBuilder.ExpectAndReturn("HasBarcode", false, testBarcode);

            var mockCatalog = (ICatalog)_mockCatalogBuilder.MockInstance;

            var scanner = new Scanner();

            var salesPoint = new SalesPoint(mockCatalog, scanner, mockScreen);

            salesPoint.Scan(testBarcode);
        }
    }
}
