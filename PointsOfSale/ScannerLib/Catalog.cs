using System;
using System.Collections.Generic;

namespace ScannerLib
{
    public interface ICatalog
    {
        PriceWithTaxes this[string barcode] { get; }

        bool HasBarcode(string barcode);
    }

    public class Catalog : ICatalog
    {
        private readonly Dictionary<string, double> _prices;

        public Catalog()
        {
            _prices = new Dictionary<string, double>();
        }

        public PriceWithTaxes this[string barcode]
        {
            get { return new PriceWithTaxes(_prices[barcode]); }
        }

        public bool HasBarcode(string barcode)
        {
            return _prices.ContainsKey(barcode);
        }

        public void AddProductInfo(string barcode, double price)
        {
            _prices.Add(barcode, price);
        }
    }
}