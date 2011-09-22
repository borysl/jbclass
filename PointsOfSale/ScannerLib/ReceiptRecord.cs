namespace ScannerLib
{
    public class ReceiptRecord
    {
        public ReceiptRecord(string itemName, ProductPriceInfo priceInfo)
        {
            ItemName = itemName;
            PriceInfo = priceInfo;
        }

        public ProductPriceInfo PriceInfo { get; set; }

        public string ItemName { get; set; }

        public override bool Equals(object obj)
        {
            var anotherReceipientList = obj as ReceiptRecord;
            if (anotherReceipientList == null) return false;

            if (!anotherReceipientList.PriceInfo.Equals(PriceInfo)) return false;
            if (!anotherReceipientList.ItemName.Equals(ItemName)) return false;

            return true;
        }
    }
}