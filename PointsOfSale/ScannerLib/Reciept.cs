using System.Collections.Generic;
using System.Linq;

namespace ScannerLib
{
    public class Reciept
    {
        private readonly List<PriceWithTaxes> _price;

        public Reciept()
        {
            _price = new List<PriceWithTaxes>();
        }

        public double NetTotal { get; set; }

        public double GstTotal { get; set; }

        public double PstTotal { get; set; }

        public double Total { get; set; }

        public void AddRecord(PriceWithTaxes price)
        {
            _price.Add(price);
        }

        public void AddRecordWithoutPst(double price)
        {
            var fullPrice = new PriceWithTaxes { NetPrice = price, PstIncluded = false };
            _price.Add(fullPrice);
        }

        public override bool Equals(object obj)
        {
            var anotherReciept = obj as Reciept;
            if (anotherReciept == null) return false;

            if (anotherReciept._price.Count != _price.Count) return false;
            if (anotherReciept.Total != Total) return false;
            if (anotherReciept.PstTotal != PstTotal) return false;
            if (anotherReciept.GstTotal != GstTotal) return false;
            if (anotherReciept.NetTotal != NetTotal) return false;

            return !_price.Where((t, i) => !t.Equals(anotherReciept._price[i])).Any();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return NetTotal.ToString();
        }
    }
}