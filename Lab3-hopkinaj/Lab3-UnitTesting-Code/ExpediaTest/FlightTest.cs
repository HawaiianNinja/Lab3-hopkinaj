using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime date1 = new DateTime(2011, 1, 1);
        private readonly DateTime date2 = new DateTime(2011, 1, 5);
        private readonly DateTime date3 = new DateTime(2011, 1, 10);

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(date1, date2, 100);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFlightThrowsOnBadDates()
        {
            new Flight(date2, date1, 1000);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFlightThrowsOnBadMiles()
        {
            new Flight(date1, date2, -10);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceWorksFor4Days()
        {
            Flight test = new Flight(date1, date2, 100);
            Assert.AreEqual(280, test.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceWorksFor9Days()
        {
            Flight test = new Flight(date1, date3, 100);
            Assert.AreEqual(380, test.getBasePrice());
        }

        [Test()]
        public void TestThatFlightEqualWorksForSameObject()
        {
            Flight test = new Flight(date1, date3, 100);
            Assert.AreEqual(test, test);
        }

        [Test()]
        public void TestThatFlightEqualWorksForDifferentObjectsWithSameValues()
        {
            Flight test1 = new Flight(date1, date3, 100);
            Flight test2 = new Flight(date1, date3, 100);
            Assert.AreEqual(test1, test2);
        }

        [Test()]
        public void TestThatFlightEqualWorksForDifferentObjectsWithDifferentStartDates()
        {
            Flight test1 = new Flight(date2, date3, 100);
            Flight test2 = new Flight(date1, date3, 100);
            Assert.AreNotEqual(test1, test2);
        }

        [Test()]
        public void TestThatFlightEqualWorksForDifferentObjectsWithDifferentEndDates()
        {
            Flight test1 = new Flight(date1, date3, 100);
            Flight test2 = new Flight(date1, date2, 100);
            Assert.AreNotEqual(test1, test2);
        }

        [Test()]
        public void TestThatFlightEqualWorksForDifferentObjectsWithDifferentMiles()
        {
            Flight test1 = new Flight(date1, date3, 100);
            Flight test2 = new Flight(date1, date3, 10000);
            Assert.AreNotEqual(test1, test2);
        }
	}
}
