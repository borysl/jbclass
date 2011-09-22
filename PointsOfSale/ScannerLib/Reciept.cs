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

            return !_price.Where((t, i) => !t.Equals(anotherReciept._price[i])).Any();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}