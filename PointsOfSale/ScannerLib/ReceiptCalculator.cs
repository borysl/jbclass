namespace ScannerLib
{
    public class ReceiptCalculator
    {
        private readonly IReceiptConsumer _recieptConsumer;
        private readonly ICatalog _catalog;

        public ReceiptCalculator(IReceiptConsumer recieptConsumer, ICatalog catalog)
        {
            _recieptConsumer = recieptConsumer;
            _catalog = catalog;
        }

        public void ProcessProduct(string barcode)
        {
            ProcessProduct(_catalog[barcode]);
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