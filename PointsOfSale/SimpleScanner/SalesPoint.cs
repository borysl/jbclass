using System;

namespace SimpleScanner
{
    public class SalesPoint
    {
        private Scanner _scanner;
        private Screen _screen;

        public void PlugScanner(Scanner scanner)
        {
            _scanner = scanner;
        }

        public void PlugLcdScreen(Screen screen)
        {
            _screen = screen;
        }

        public void Scan(string s)
        {
            _screen.Display = "EUR 500.00";
        }
    }
}