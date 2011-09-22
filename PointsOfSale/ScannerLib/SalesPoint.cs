namespace ScannerLib
{
    public class SalesPoint
    {
        private readonly ICatalog _catalog;
        private readonly IScanner _scanner;
        private readonly IScreen _screen;

        public SalesPoint(ICatalog catalog, IScanner scanner, IScreen screen)
        {
            _catalog = catalog;

            _scanner = scanner;
            _scanner.BarcodeScanned += (s, e) => { Scan(e.Barcode); };

            _screen = screen;
        }

        public void Scan(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                _screen.DisplayEmptyBarcodeError();
            } 
            else if (_catalog.HasBarcode(barcode))
            {
                var price = _catalog[barcode];
                
                _screen.DisplayPrice(price);
            }
            else
            {
                _screen.DisplayProductNotFound(barcode);
            }
        }
    }
}