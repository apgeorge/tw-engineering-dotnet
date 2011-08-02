using System.Collections.Generic;
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    internal class CustomerTests
    {
        [Test]
        public void Empty()
        {
            var customer = new Customer("John Smith");
            const string noRentalsStatement = "Rental Record for John Smith\n"
                                              + "Amount charged is $0.00\n";
            Assert.AreEqual(noRentalsStatement, customer.Statement(new List<Rental>()));
        }

        [Test]
        public void NonEmpty()
        {
            const string expected = "Rental Record for John Smith\n"
                                    + "  Monty Python and the Holy Grail  -  $3.00\n"
                                    + "  Ran  -  $1.00\n"
                                    + "  LA Confidential  -  $2.00\n"
                                    + "  Star Trek 13.2  -  $1.00\n"
                                    + "  Wallace and Gromit  -  $6.00\n"
                                    + "Amount charged is $13.00\n";

            var customer = new Customer("John Smith");

            var montyPython = new Movie("Monty Python and the Holy Grail");
            var ran = new Movie("Ran");
            var laConfidential = new Movie("LA Confidential");
            var starTrek = new Movie("Star Trek 13.2");
            var wallaceAndGromit = new Movie("Wallace and Gromit");

            var mixedRentals = new List<Rental>();
            mixedRentals.Add(new Rental(montyPython, 3));
            mixedRentals.Add(new Rental(ran, 1));
            mixedRentals.Add(new Rental(laConfidential, 2));
            mixedRentals.Add(new Rental(starTrek, 1));
            mixedRentals.Add(new Rental(wallaceAndGromit, 6));

            Assert.AreEqual(expected, customer.Statement(mixedRentals));
        }
    }
}