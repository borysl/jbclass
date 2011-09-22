using NUnit.Framework;
using Rhino.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class RecieptCalculatorTests
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
        public void CreateRecieptForSingleItemWithoutPst()
        {
            var etalonReciept = new Reciept();
            var price = new ProductPriceInfo(500.00);

            etalonReciept.AddRecord(price);
            etalonReciept.NetTotal = 500.00;
            etalonReciept.GstTotal = 25.00;
            etalonReciept.PstTotal = 0.0;
            etalonReciept.Total = 525.00;

            var recieptConsumer = _mocks.StrictMock<IRecieptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReciept(etalonReciept); });

            _mocks.ReplayAll();

            var recieptCalculator = new RecieptCalculator(recieptConsumer);

            recieptCalculator.ProcessProduct(price);
        }

        [Test]
        public void CreateRecieptForSingleItemWithPst()
        {
            var etalonReciept = new Reciept();

            var price = new ProductPriceInfo(100.00) { PstIncluded = true };

            etalonReciept.AddRecord(price);
            etalonReciept.NetTotal = 100.00;
            etalonReciept.GstTotal = 5.00;
            etalonReciept.PstTotal = 10.5;
            etalonReciept.Total = 115.5;

            var recieptConsumer = _mocks.StrictMock<IRecieptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReciept(etalonReciept); });

            _mocks.ReplayAll();

            var recieptCalculator = new RecieptCalculator(recieptConsumer);

            recieptCalculator.ProcessProduct(price);
        }
    }
}
