namespace ScannerLib
{
    public class ReceiptCalculator
    {
        private readonly IReceiptConsumer _receiptConsumer;
        private readonly ICatalog _catalog;
        private Receipt _receipt;

        public ReceiptCalculator(IReceiptConsumer receiptConsumer, ICatalog catalog)
        {
            _receiptConsumer = receiptConsumer;
            _catalog = catalog;
            PullTheRollingPaper();
        }

        public void ProcessProduct(string barcode)
        {
            ProcessProduct(_catalog[barcode]);
        }

        public void ProcessProduct(ProductPriceInfo price)
        {
            _receipt.AddRecord(price);
            _receipt.NetTotal += price.NetPrice;
            _receipt.GstTotal += SalesCalculator.CalculateGst(price);
            _receipt.PstTotal += SalesCalculator.CalculatePst(price);
            _receipt.Total += SalesCalculator.CalculateCost(price);
        }

        public void Print()
        {
            _receiptConsumer.PrintReceipt(_receipt);
            PullTheRollingPaper();
        }

        private void PullTheRollingPaper()
        {
            _receipt = new Receipt();
        }
    }
}