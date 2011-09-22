namespace ScannerLib
{
    public class ReceiptCalculator
    {
        private readonly IReceiptConsumer _recieptConsumer;

        public ReceiptCalculator(IReceiptConsumer recieptConsumer)
        {
            _recieptConsumer = recieptConsumer;
        }

        public void ProcessProduct(ProductPriceInfo price)
        {
            var reciept = new Receipt();
            reciept.AddRecord(price);
            reciept.NetTotal = price.NetPrice;
            reciept.GstTotal = SalesCalculator.CalculateGst(price);
            reciept.PstTotal = SalesCalculator.CalculatePst(price);
            reciept.Total = SalesCalculator.CalculateCost(price);
            _recieptConsumer.PrintReceipt(reciept);
        }
    }
}