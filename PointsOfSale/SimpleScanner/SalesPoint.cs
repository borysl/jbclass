using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimpleScanner
{
    public class SalesPoint
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        private Dictionary<string, double> _priceList;

        private Scanner _scanner;
        private Screen _screen;

        public SalesPoint()
        {
            _numberFormatInfo = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
            _priceList = new Dictionary<string, double>();
            _priceList.Add("12345", 500.00);
        }

        public void PlugScanner(Scanner scanner)
        {
            _scanner = scanner;
            _scanner.BarcodeScanned += (s, e) => { Scan(e.Barcode); };
        }

        public void PlugLcdScreen(Screen screen)
        {
            _screen = screen;
        }

        private void Scan(string barcode)
        {
            if (_priceList.ContainsKey(barcode))
            {
                var price = _priceList[barcode];
                
                _screen.Display = string.Format(_numberFormatInfo, "EUR {0:###.00}", price);
            }
            else
            {
                _screen.Display = string.Format("No product found: {0}", barcode);
            }
        }
    }
}