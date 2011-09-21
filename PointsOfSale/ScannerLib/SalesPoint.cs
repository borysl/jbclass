using System.Collections.Generic;
using System.Globalization;

namespace ScannerLib
{
    public class SalesPoint
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        private Dictionary<string, double> _priceList;

        private Scanner _scanner;
        private Screen _screen;

        public SalesPoint()
        {
        }

        public SalesPoint(Scanner scanner, Screen screen)
        {
            _numberFormatInfo = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
            _priceList = new Dictionary<string, double>();
            _priceList.Add("12345", 500.00);

            _scanner = scanner;
            _scanner.BarcodeScanned += (s, e) => { Scan(e.Barcode); };

            _screen = screen;
        }

        private void Scan(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                _screen.Display = "Scan error: Empty barcode.";
            } 
            else if (_priceList.ContainsKey(barcode))
            {
                var price = _priceList[barcode];
                
                _screen.Display = string.Format(_numberFormatInfo, "EUR {0:###.00}", price);
            }
            else
            {
                _screen.Display = string.Format("No product found: {0}.", barcode);
            }
        }
    }
}