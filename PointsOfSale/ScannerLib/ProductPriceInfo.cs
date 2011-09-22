namespace ScannerLib
{
    public class ProductPriceInfo : PriceWithTaxes
    {
        public double Cost
        {
            get
            {
                var fullPrice = NetPrice * 1.05;
                if (PstIncluded) fullPrice *= 1.1;
                return fullPrice;
            }
        }
    }
}