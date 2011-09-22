namespace ScannerLib
{
    public class RecieptCalculator
    {
        private readonly IRecieptConsumer _recieptConsumer;

        public RecieptCalculator(IRecieptConsumer recieptConsumer)
        {
            _recieptConsumer = recieptConsumer;
        }

        public void ProcessProduct(ProductPriceInfo price)
        {
            var reciept = new Reciept();
            reciept.AddRecord(price);
            reciept.NetTotal = price.NetPrice;
            reciept.GstTotal = SalesCalculator.CalculateGst(price);
            reciept.PstTotal = SalesCalculator.CalculatePst(price);
            reciept.Total = SalesCalculator.CalculateCost(price);
            _recieptConsumer.PrintReciept(reciept);
        }
    }
}