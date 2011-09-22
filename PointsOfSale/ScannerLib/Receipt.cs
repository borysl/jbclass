using System.Collections.Generic;
using System.Linq;

namespace ScannerLib
{
    public class Receipt
    {
        private readonly List<ProductPriceInfo> _price;

        public Receipt()
        {
            _price = new List<ProductPriceInfo>();
        }

        public double NetTotal { get; set; }

        public double GstTotal { get; set; }

        public double PstTotal { get; set; }

        public double Total { get; set; }

        public void AddRecord(ProductPriceInfo price)
        {
            _price.Add(price);
        }

        public void AddRecordWithoutPst(double price)
        {
            var fullPrice = new ProductPriceInfo { NetPrice = price, PstIncluded = false };
            _price.Add(fullPrice);
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