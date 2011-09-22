using NUnit.Framework;
using Rhino.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class RecieptCalculatorTests
    {
        [Test]
        public void CreateRecieptForSingleItemWithoutPst()
        {
            var mocks = new MockRepository();

            var etalonReciept = new Reciept();
            etalonReciept.AddRecordWithoutPst(500.00);
            etalonReciept.NetTotal = 500.00;
            etalonReciept.GstTotal = 25.00;
            etalonReciept.PstTotal = 0.0;
            etalonReciept.Total = 525.00;

            var recieptConsumer = mocks.StrictMock<IRecieptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReciept(etalonReciept); });

            mocks.ReplayAll();

            var recieptCalculator = new RecieptCalculator(recieptConsumer);

            var price = new PriceWithTaxes(500.00);

            recieptCalculator.ProcessProduct(price);

            mocks.VerifyAll();
        }
    }
}
