namespace ScannerLib
{
    public class PriceWithTaxes
    {
        public PriceWithTaxes()
        {
        }

        public PriceWithTaxes(double netPrice)
        {
            NetPrice = netPrice;
        }

        public double NetPrice { get; set; }

        public bool PstIncluded { get; set; }

        public override bool Equals(object obj)
        {
            var anotherPrice = obj as PriceWithTaxes;
            if (anotherPrice == null) return false;

            if (anotherPrice.NetPrice != NetPrice) return false;
            if (anotherPrice.PstIncluded != PstIncluded) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return (int)NetPrice;
        }
    }
}