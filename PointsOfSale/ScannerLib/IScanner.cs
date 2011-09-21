using System;

namespace ScannerLib
{
    public interface IScanner
    {
        event EventHandler<Scanner.BarcodeEventArgs> BarcodeScanned;

        void OnBarcode(string barcode);
    }
}