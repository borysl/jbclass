using System;

namespace SimpleScanner
{
    public class Scanner : IScanner
    {
        public class BarcodeEventArgs : EventArgs
        {
            public string Barcode { get; private set; }

            public BarcodeEventArgs(string barcode)
            {
                Barcode = barcode;
            }
        }

        public event EventHandler<BarcodeEventArgs> BarcodeScanned;

        public void OnBarcode(string barcode)
        {
            var barcodeScanned = BarcodeScanned;

            if (barcodeScanned != null)
            {
                barcodeScanned(this, new BarcodeEventArgs(barcode));
            }
        }
    }
}
