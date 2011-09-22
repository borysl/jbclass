using System.Globalization;

namespace ScannerLib
{
    public class CashRegisterDisplay : ICashRegisterDisplay
    {
        private readonly NumberFormatInfo _numberFormatInfo;

        public CashRegisterDisplay()
        {
            _numberFormatInfo = new NumberFormatInfo { CurrencyDecimalSeparator = "." };
        }

        public string Display
        {
            get;
            private set;
        }

        public void DisplayProductNotFound(string barcode)
        {
            Display = string.Format("No product found: {0}.", barcode);
        }

        public void DisplayEmptyBarcodeError()
        {
            Display = "Scan error: Empty barcode.";
        }

        public void DisplayProductInfo(PriceWithTaxes testPrice)
        {
            var productPriceInfo = new ProductPriceInfo
                                        {
                                            NetPrice = testPrice.NetPrice,
                                            PstIncluded = testPrice.PstIncluded,
                                        };

            DisplayProductInfo(productPriceInfo);
        }

        public void DisplayProductInfo(ProductPriceInfo testPrice)
        {
            Display = string.Format(
                _numberFormatInfo, 
                "EUR {0:###.00} G{2}\nTotal: EUR {1:###.00}", 
                testPrice.NetPrice, 
                testPrice.Cost,
                testPrice.PstIncluded ? "P" : string.Empty);
        }
    }
}
