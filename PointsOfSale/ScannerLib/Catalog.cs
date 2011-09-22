using System.Collections.Generic;

namespace ScannerLib
{
    public interface ICatalog
    {
        ProductPriceInfo this[string barcode] { get; }

        bool HasBarcode(string barcode);
    }

    public interface IEditableCatalog : ICatalog
    {
        void AddPriceWithoutPst(string barcode, double price);

        void AddPriceWithPst(string barcode, double price);
    }

    public class Catalog : IEditableCatalog
    {
        private readonly Dictionary<string, ProductPriceInfo> _prices;

        public Catalog()
        {
            _prices = new Dictionary<string, ProductPriceInfo>();
        }

        public ProductPriceInfo this[string barcode]
        {
            get { return _prices[barcode]; }
        }

        public bool HasBarcode(string barcode)
        {
            return _prices.ContainsKey(barcode);
        }

        void IEditableCatalog.AddPriceWithoutPst(string barcode, double price)
        {
            _prices.Add(barcode, new ProductPriceInfo(price));
        }

        void IEditableCatalog.AddPriceWithPst(string barcode, double price)
        {
            _prices.Add(barcode, new ProductPriceInfo(price) { PstIncluded = true });
        }
    }
}