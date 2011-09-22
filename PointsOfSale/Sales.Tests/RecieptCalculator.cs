using ScannerLib;

namespace Sales.Tests
{
    public class RecieptCalculator
    {
        private readonly IRecieptConsumer _recieptConsumer;

        public RecieptCalculator(IRecieptConsumer recieptConsumer)
        {
            _recieptConsumer = recieptConsumer;
        }

        public void ProcessProduct(PriceWithTaxes price)
        {
            var reciept = new Reciept();
            reciept.AddRecordWithoutPst(price.NetPrice);
            _recieptConsumer.PrintReciept(reciept);
        }
    }
}