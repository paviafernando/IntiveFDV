using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental;

namespace BikeRentalTest
{
    [TestClass]
    public class RentalTest
    {
        [TestMethod]
        public void ByHourGetPriceReturns5()
        {
            decimal price = 5;

            Rental rental = new ByHourRental();

            Assert.AreEqual(rental.Price, price);

        }
        [TestMethod]
        public void ByDayGetPriceReturns20()
        {
            decimal price = 20;

            Rental rental = new ByDayRental();

            Assert.AreEqual(rental.Price, price);

        }
        [TestMethod]
        public void ByWeekGetPriceReturns60()
        {
            decimal price = 60;

            Rental rental = new ByWeekRental();

            Assert.AreEqual(rental.Price, price);

        }
        [TestMethod]
        public void BatchRentalReturnsTotal()
        {
            decimal total = (5 + 20 + 60);

            BatchRental batch = new BatchRental();

            batch.AddRental(new ByDayRental());
            batch.AddRental(new ByHourRental());
            batch.AddRental(new ByWeekRental());

            Assert.AreEqual(batch.GetTotal(), total);

        }
        [TestMethod]
        public void PromoRentalReturnsDiscount30PercentOfTotal()
        {
            decimal total = (5 + 20 + 60) * (decimal)0.7;

            BatchRental batch = new BatchRental();

            batch.AddRental(new ByDayRental());
            batch.AddRental(new ByHourRental());
            batch.AddRental(new ByWeekRental());


            Assert.AreEqual(batch.GetPromo(), total);

        }
        [TestMethod]
        public void PromoRentalLessThan3ReturnsTotalWithoutDiscount()
        {
            decimal total = (5 + 60);

            BatchRental batch = new BatchRental();

            batch.AddRental(new ByHourRental());
            batch.AddRental(new ByWeekRental());


            Assert.AreEqual(batch.GetPromo(), total);

        }
        [TestMethod]
        public void PromoRentalMoreThan5ReturnsTotalWithoutDiscount()
        {
            decimal total = 60 * 6;

            BatchRental batch = new BatchRental();

            batch.AddRental(new ByWeekRental());
            batch.AddRental(new ByWeekRental());
            batch.AddRental(new ByWeekRental());
            batch.AddRental(new ByWeekRental());
            batch.AddRental(new ByWeekRental());
            batch.AddRental(new ByWeekRental());


            Assert.AreEqual(batch.GetPromo(), total);

        }
    }
}
