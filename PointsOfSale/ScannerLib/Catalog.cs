using System.Collections.Generic;

namespace ScannerLib
{
    public interface ICatalog
    {
        double this[string barcode] { get; }

        bool HasBarcode(string barcode);
    }

    public class Catalog : ICatalog
    {
        private readonly Dictionary<string, double> _prices;

        public Catalog()
        {
            _prices = new Dictionary<string, double>();
            _prices.Add("12345", 500.00);
            _prices.Add("23456", 750.00);
        }

        public double this[string barcode]
        {
            get { return _prices[barcode]; }
        }

        public bool HasBarcode(string barcode)
        {
            return _prices.ContainsKey(barcode);
        }
    }
}