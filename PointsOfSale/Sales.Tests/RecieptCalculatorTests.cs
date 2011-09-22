using System;
using NUnit.Framework;
using Rhino.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class ReceiptCalculatorTests
    {
        private MockRepository _mocks;
        private ICatalog _catalog;

        [SetUp]
        public void InitializeMock()
        {
            _mocks = new MockRepository();

            _catalog = _mocks.Stub<ICatalog>();
            _catalog.Stub(_ => _["12345"]).Return(new ProductPriceInfo(500.00));
            _catalog.Stub(_ => _["23456"]).Return(new ProductPriceInfo(100.00) { PstIncluded = true });
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
            var price = new ReceiptRecord("Item #12345", 500.00);

            etalonReceipt.AddRecord(price);
            etalonReceipt.NetTotal = 500.00;
            etalonReceipt.GstTotal = 25.00;
            etalonReceipt.PstTotal = 0.0;
            etalonReceipt.Total = 525.00;

            var recieptConsumer = _mocks.StrictMock<IReceiptConsumer>();
            Expect.Call(() => recieptConsumer.PrintReceipt(etalonReceipt));

            _mocks.ReplayAll();

            var recieptCalculator = new ReceiptCalculator(recieptConsumer, _catalog);

            recieptCalculator.ProcessProduct("12345");
            recieptCalculator.Print();
        }

        [Test]
        public void CreateReceiptForSingleItemWithPst()
        {
            var etalonReceipt = new Receipt();

            var price = new ReceiptRecord("Item #23456", 100.00) { PstIncluded = true };

            etalonReceipt.AddRecord(price);
            etalonReceipt.NetTotal = 100.00;
            etalonReceipt.GstTotal = 5.00;
            etalonReceipt.PstTotal = 10.5;
            etalonReceipt.Total = 115.5;

            var recieptConsumer = _mocks.StrictMock<IReceiptConsumer>();
            Expect.Call(() => recieptConsumer.PrintReceipt(etalonReceipt));

            _mocks.ReplayAll();

            var recieptCalculator = new ReceiptCalculator(recieptConsumer, _catalog);

            recieptCalculator.ProcessProduct("23456");
            recieptCalculator.Print();
        }

        [Test]
        public void CreateReceiptWithMultiplePositions()
        {
            var etalonReceipt = new Receipt();

            var priceOne = new ReceiptRecord("Item #12345", 500.00);
            var priceTwo = new ReceiptRecord("Item #23456", 100.00) { PstIncluded = true };

            etalonReceipt.AddRecord(priceOne);
            etalonReceipt.AddRecord(priceTwo);
            etalonReceipt.NetTotal = 600.00;
            etalonReceipt.GstTotal = 30.00;
            etalonReceipt.PstTotal = 10.5;
            etalonReceipt.Total = 640.5;

            var recieptConsumer = _mocks.StrictMock<IReceiptConsumer>();
            Expect.Call(() => recieptConsumer.PrintReceipt(etalonReceipt));

            _mocks.ReplayAll();

            var recieptCalculator = new ReceiptCalculator(recieptConsumer, _catalog);

            recieptCalculator.ProcessProduct("12345");
            recieptCalculator.ProcessProduct("23456");
            recieptCalculator.Print();
        }
    }

    public class ReceiptRecord : ProductPriceInfo
    {
        public ReceiptRecord(string itemName, double price)
            : base(price)
        {
            ItemName = itemName;
        }

        public string ItemName { get; set; }
    }
}
