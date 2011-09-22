using NUnit.Framework;
using Rhino.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class ReceiptCalculatorTests
    {
        private MockRepository _mocks;

        [SetUp]
        public void InitializeMock()
        {
            _mocks = new MockRepository();
        }

        [TearDown]
        public void Verify()
        {
            _mocks.VerifyAll();
        }

        [Test]
        public void CreateReceiptForSingleItemWithoutPst()
        {
            var etalonReceipt = new Receipt();
            var price = new ProductPriceInfo(500.00);

            etalonReceipt.AddRecord(price);
            etalonReceipt.NetTotal = 500.00;
            etalonReceipt.GstTotal = 25.00;
            etalonReceipt.PstTotal = 0.0;
            etalonReceipt.Total = 525.00;

            var recieptConsumer = _mocks.StrictMock<IReceiptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReceipt(etalonReceipt); });

            _mocks.ReplayAll();

            var recieptCalculator = new ReceiptCalculator(recieptConsumer);

            recieptCalculator.ProcessProduct(price);
        }

        [Test]
        public void CreateReceiptForSingleItemWithPst()
        {
            var etalonReceipt = new Receipt();

            var price = new ProductPriceInfo(100.00) { PstIncluded = true };

            etalonReceipt.AddRecord(price);
            etalonReceipt.NetTotal = 100.00;
            etalonReceipt.GstTotal = 5.00;
            etalonReceipt.PstTotal = 10.5;
            etalonReceipt.Total = 115.5;

            var recieptConsumer = _mocks.StrictMock<IReceiptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReceipt(etalonReceipt); });

            _mocks.ReplayAll();

            var recieptCalculator = new ReceiptCalculator(recieptConsumer);

            recieptCalculator.ProcessProduct(price);
        }
    }
}
