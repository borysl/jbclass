namespace ScannerLib
{
    public class RecieptCalculator
    {
        private readonly IRecieptConsumer _recieptConsumer;

        public RecieptCalculator(IRecieptConsumer recieptConsumer)
        {
            _recieptConsumer = recieptConsumer;
        }

        public void ProcessProduct(PriceWithTaxes price)
        {
            var reciept = new Reciept();
            reciept.AddRecordWithoutPst(price.NetPrice);
            reciept.PstTotal = 0;
            reciept.NetTotal = price.NetPrice;
            reciept.GstTotal = SalesCalculator.CalculateGst(price);
            reciept.Total = SalesCalculator.CalculateCost(price);
            _recieptConsumer.PrintReciept(reciept);
        }
    }
}