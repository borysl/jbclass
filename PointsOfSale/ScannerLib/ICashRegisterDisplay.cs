namespace ScannerLib
{
    public interface ICashRegisterDisplay
    {
        void DisplayProductNotFound(string barcode);

        void DisplayEmptyBarcodeError();

        void DisplayProductInfo(PriceWithTaxes testPrice);
    }
}