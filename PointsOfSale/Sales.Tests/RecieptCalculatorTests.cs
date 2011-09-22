using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using Rhino.Mocks;
using ScannerLib;

namespace Sales.Tests
{
    [TestFixture]
    public class RecieptCalculatorTests
    {

        [Test]
        public void CreateRecieptForSingleItemWithoutPst()
        {
            var mocks = new MockRepository();

            var etalonReciept = new Reciept();
            etalonReciept.AddRecordWithoutPst(500.00);

            var recieptConsumer = mocks.StrictMock<IRecieptConsumer>();
            Expect.Call(delegate { recieptConsumer.PrintReciept(etalonReciept); });

            mocks.ReplayAll();

            var recieptCalculator = new RecieptCalculator(recieptConsumer);

            var price = new PriceWithTaxes(500.00);

            recieptCalculator.ProcessProduct(price);

            mocks.VerifyAll();
        }

    }

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
            _recieptConsumer.PrintReciept(reciept);
        }
    }

    public interface IRecieptConsumer
    {
        void PrintReciept(Reciept reciept);
    }

    public class Reciept
    {
        private readonly List<PriceWithTaxes> _price;

        public Reciept()
        {
            _price = new List<PriceWithTaxes>();
        }

        public void AddRecordWithoutPst(double price)
        {
            var fullPrice = new PriceWithTaxes { NetPrice = price, PstIncluded = false };
            _price.Add(fullPrice);
        }

        public override bool Equals(object obj)
        {
            var anotherReciept = obj as Reciept;
            if (anotherReciept == null) return false;

            if (anotherReciept._price.Count != _price.Count) return false;

            return !_price.Where((t, i) => !t.Equals(anotherReciept._price[i])).Any();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
