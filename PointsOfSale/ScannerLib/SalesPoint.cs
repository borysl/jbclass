namespace ScannerLib
{
    public class SalesPoint
    {
        private Catalog _catalog;

        private Scanner _scanner;
        private Screen _screen;

        public SalesPoint()
        {
        }

        public SalesPoint(Scanner scanner, Screen screen)
        {
            _catalog = new Catalog();

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