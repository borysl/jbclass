using System.Collections.Generic;
using System.Globalization;

namespace ScannerLib
{
    public class SalesPoint
    {
        private Dictionary<string, double> _priceList;

        private Scanner _scanner;
        private Screen _screen;

        public SalesPoint()
        {
        }

        public SalesPoint(Scanner scanner, Screen screen)
        {
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
                _screen.DisplayEmptyBarcodeError();
            } 
            else if (_priceList.ContainsKey(barcode))
            {
                var price = _priceList[barcode];
                
                _screen.DisplayPrice(price);
            }
            else
            {
                _screen.DisplayProductNotFound(barcode);
            }
        }
    }
}