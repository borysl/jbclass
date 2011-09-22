namespace ScannerLib
{
    public class SalesPoint
    {
        private readonly ICatalog _catalog;
        private readonly IScanner _scanner;
        private readonly ICashRegisterDisplay _cashRegisterDisplay;

        public SalesPoint(ICatalog catalog, IScanner scanner, ICashRegisterDisplay cashRegisterDisplay)
        {
            _catalog = catalog;

            _scanner = scanner;
            _scanner.BarcodeScanned += (s, e) => { Scan(e.Barcode); };

            _cashRegisterDisplay = cashRegisterDisplay;
        }

        public void Scan(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                _cashRegisterDisplay.DisplayEmptyBarcodeError();
            } 
            else if (_catalog.HasBarcode(barcode))
            {
                var price = _catalog[barcode];
                
                _cashRegisterDisplay.DisplayProductInfo(price);
            }
            else
            {
                _cashRegisterDisplay.DisplayProductNotFound(barcode);
            }
        }
    }
}