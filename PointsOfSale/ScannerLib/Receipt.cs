using System.Collections.Generic;
using System.Linq;

namespace ScannerLib
{
    public class Receipt
    {
        private readonly List<ReceiptRecord> _price;

        public Receipt()
        {
            _price = new List<ReceiptRecord>();
        }

        public double NetTotal { get; set; }

        public double GstTotal { get; set; }

        public double PstTotal { get; set; }

        public double Total { get; set; }

        public void AddRecord(ReceiptRecord price)
        {
            _price.Add(price);
        }

        public override bool Equals(object obj)
        {
            var anotherReceipt = obj as Receipt;
            if (anotherReceipt == null) return false;

            if (anotherReceipt._price.Count != _price.Count) return false;
            if (anotherReceipt.Total != Total) return false;
            if (anotherReceipt.PstTotal != PstTotal) return false;
            if (anotherReceipt.GstTotal != GstTotal) return false;
            if (anotherReceipt.NetTotal != NetTotal) return false;

            return !_price.Where((t, i) => !t.Equals(anotherReceipt._price[i])).Any();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}