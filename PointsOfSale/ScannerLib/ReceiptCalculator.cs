namespace ScannerLib
{
    public class ReceiptCalculator
    {
        private readonly IReceiptConsumer _recieptConsumer;
        private readonly ICatalog _catalog;
        private Receipt _reciept;

        public ReceiptCalculator(IReceiptConsumer recieptConsumer, ICatalog catalog)
        {
            _recieptConsumer = recieptConsumer;
            _catalog = catalog;
            PullTheRollingPaper();
        }

        public void ProcessProduct(string barcode)
        {
            ProcessProduct(_catalog[barcode]);
        }

        public void ProcessProduct(ProductPriceInfo price)
        {
            _reciept.AddRecord(price);
            _reciept.NetTotal += price.NetPrice;
            _reciept.GstTotal += SalesCalculator.CalculateGst(price);
            _reciept.PstTotal += SalesCalculator.CalculatePst(price);
            _reciept.Total += SalesCalculator.CalculateCost(price);
        }

        public void Print()
        {
            _recieptConsumer.PrintReceipt(_reciept);
            PullTheRollingPaper();
        }

        private void PullTheRollingPaper()
        {
            _reciept = new Receipt();
        }
    }
}