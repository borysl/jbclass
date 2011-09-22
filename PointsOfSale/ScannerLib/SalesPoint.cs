namespace ScannerLib
{
    public class SalesPoint : ISalesPoint
    {
        private readonly ICatalog _catalog;
        private readonly ICashRegisterDisplay _cashRegisterDisplay;

        public SalesPoint(ICatalog catalog, ICashRegisterDisplay cashRegisterDisplay)
        {
            _catalog = catalog;

            _cashRegisterDisplay = cashRegisterDisplay;
        }

        public void OnBarcode(string barcode)
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