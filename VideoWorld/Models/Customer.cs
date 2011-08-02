﻿using System;
using System.Collections.Generic;
using Ninject;

namespace VideoWorld.Models
{
    public class Customer
    {
        private readonly Cart cart = new Cart();

        public Customer(string name)
        {
            Name = name;
        }

        [Inject]
        public Customer()
        {
            Name = "Unknown Customer";
        }

        public Cart Cart
        {
            get { return  cart; }
        }

        protected string Name { get; private set; }

        public string Statement(List<Rental> newRentals)
        {
            String result = "Rental Record for " + Name + "\n";

            decimal totalAmount = 0.00m;
            foreach (Rental rental in newRentals)
            {
                // show figures for this rental
                int rentalDays = rental.Period;

                result += "  " + rental.Movie.Title + "  -  $"
                          + rental.Movie.GetCharge(rentalDays) + "\n";

                totalAmount += rental.Movie.GetCharge(rentalDays);

            }

            // add footer lines
            result += "Amount charged is $" + totalAmount + "\n";
            return result;
        }

    }
}