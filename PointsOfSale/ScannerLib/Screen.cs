using System.Globalization;

namespace ScannerLib
{
    public class Screen
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
    }
}
