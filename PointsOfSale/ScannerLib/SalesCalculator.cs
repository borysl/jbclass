using System;

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
            return price.NetPrice + CalculatePst(price) + CalculateGst(price);
        }

        public static double CalculatePst(PriceWithTaxes price)
        {
            return price.PstIncluded ? (price.NetPrice + CalculateGst(price)) * 0.1 : 0;
        }
    }
}