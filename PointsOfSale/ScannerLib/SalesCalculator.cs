namespace ScannerLib
{
    public static class SalesCalculator
    {
        public static double CalculateGst(PriceWithTaxes price)
        {
            return price.NetPrice * 0.05;
        }

        public static double CalculateCost(PriceWithTaxes price)
        {
            return price.NetPrice + CalculateGst(price);
        }
    }
}