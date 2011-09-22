using System.Globalization;

namespace ScannerLib
{
    public interface IScreen
    {
        void DisplayPrice(double price);

        void DisplayProductNotFound(string barcode);

        void DisplayEmptyBarcodeError();

        void DisplayPrice(PriceWithTaxes testPrice);
    }

    public class Screen : IScreen
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        public Screen()
        {
            _numberFormatInfo = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
        }

        public string Display
        {
            get;
            private set;
        }

        public void DisplayPrice(double price)
        {
            Display = string.Format(_numberFormatInfo, "EUR {0:###.00}", price);
        }

        public void DisplayProductNotFound(string barcode)
        {
            Display = string.Format("No product found: {0}.", barcode);
        }

        public void DisplayEmptyBarcodeError()
        {
            Display = "Scan error: Empty barcode.";
        }

        public void DisplayPrice(PriceWithTaxes testPrice)
        {
            DisplayPrice(testPrice.NetPrice);
        }
    }
}
