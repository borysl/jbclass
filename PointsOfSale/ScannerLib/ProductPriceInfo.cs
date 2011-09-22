namespace ScannerLib
{
    public class ProductPriceInfo : PriceWithTaxes
    {
        public double Cost
        {
            get
            {
                return SalesCalculator.CalculateCost(this);
            }
        }
    }
}