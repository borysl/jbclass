using System;

namespace SimpleScanner
{
    public interface IScanner
    {
        void OnBarcode(string barcode);
    }

    public class Scanner : IScanner
    {
        public void OnBarcode(string barcode)
        {
            throw new NotImplementedException();
        }
    }
}
