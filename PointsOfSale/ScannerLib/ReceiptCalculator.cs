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
            var itemName = string.Format("Item #{0}", barcode);
            var receiptRecord = new ReceiptRecord(itemName, _catalog[barcode]);
            ProcessProduct(receiptRecord);
        }

        public void ProcessProduct(ReceiptRecord receiptRecord)
        {
            _receipt.AddRecord(receiptRecord);
            _receipt.NetTotal += receiptRecord.PriceInfo.NetPrice;
            _receipt.GstTotal += SalesCalculator.CalculateGst(receiptRecord.PriceInfo);
            _receipt.PstTotal += SalesCalculator.CalculatePst(receiptRecord.PriceInfo);
            _receipt.Total += SalesCalculator.CalculateCost(receiptRecord.PriceInfo);
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