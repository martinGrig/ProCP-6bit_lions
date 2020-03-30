using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherScript
{ /// <summary>
  /// Script for customers (character, normal distribution, movement)
  /// The customers’ purpose of visiting the mini-mall will be different. They will be randomized by using the Normal Distribution
  /// method. This would mean that a simulation which was run twice would output similar but not identical results. 
  /// A list of randomizable characteristics is presented below.
  ///     Desired product(s)
  ///     Age
  ///     Gender - 60% females
  ///     Free time - 66% (less than 1 h), 30 (more than 3 h)
  ///     Budget
  ///     Need for quality/quantity(e.g.Shop a lot of cheap things / Shop for good quality brands)
  ///     
  ///     Purpose of visiting(shopping, includes all shopping preferences, or need for a bathroom)
  /// 
  /// normal distribution
  ///     frequency of spawning - 80% (less than 1 per week)
  ///     
  /// </summary>
    class Customer
    {
        private static int id = 0;
        private int customerID;
        private int age;
        private string gender; //f/m
        private int freetime;
        private double budget;
        private string purpose;
        private Category category;

        public Customer()
        {
            //run all methods
            this.customerID = Customer.id++;
            this.age = SetAge();
            this.gender = SetGender();
            this.freetime = SetFreeTime();
            this.budget = SetBudget();
            this.purpose = SetPurpose();
            this.category = SetCategory();
        }

        private int SetAge()
        {
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.168)
            {
                return random.Next(15, 21);
            }
            else if (result > 0.168 && result <= 0.477)
            {
                return random.Next(21, 31);
            }
            else if (result > 0.477 && result <= 0.6525)
            {
                return random.Next(31, 41);
            }
            else if (result > 0.6525 && result <= 0.7765)
            {
                return random.Next(41, 51);
            }
            else if (result > 0.7765 && result <= 0.901)
            {
                return random.Next(51, 61);
            }
            else
            {
                return random.Next(60, 76);
            }
        }

        private string SetGender()
        {

            Random random = new Random();


            if (random.NextDouble() <= 0.602)
            {
                return "f";
            }
            else
            {
                return "m";
            }
        }

        private int SetFreeTime()
        {
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.66)
            {
                return random.Next(30, 91); //30 mins to 1,5 hours
            }
            else if (result > 0.66 && result <= 0.9)
            {
                return random.Next(91, 181); // 1,5 hours to 3 hours
            }
            else
            {
                return random.Next(181, 301); // 3 hours to 5 hours
            }
        }
        private double SetBudget(.........)
        {
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.5)
            {
                return random.Next(0, 51);
            }
            else if (result > 0.5 && result <= 0.7)
            {
                return random.Next(51, 101);
            }
            else if (result > 0.7 && result <= 0.85)
            {
                return random.Next(101, 201);
            }
            else if (result > 0.85 && result <= 0.95)
            {
                return random.Next(201, 501);
            }
            else
            {
                return random.Next(501, 1001);
            }
        }
        private string SetPurpose() //list with chances, after the free time, array
        {
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.5)
            {
                return "NoPurpose";
            }
            else if (result > 0.5 && result <= 0.7)
            {
                return "Fitness";
            }
            else if (result > 0.7 && result <= 0.85)
            {
                return "Clothes";
            }
            else if (result > 0.85 && result <= 0.95)
            {
                return "Cinema";
            }
            else if (result > 0.85 && result <= 0.95)
            {
                return "Tech";
            }
            else
            {
                return "Bathroom";
            }
        }
       

        public int GetAge()
        {
            return age;
        }
        public string GetGender()
        {
            return gender;
        }
        public int GetFreeTime()
        {
            return freetime;
        }
        public double GetBudget()
        {
            return budget;
        }
        public string GetPurpose()
        {
            return purpose;
        }
        public Category GetCategory()
        {
            return category;
        }
        //choose shop: based on purpose, budget and free time

        //buy product: based on random price and budget
        public void BuySomething(double priceOfProduct)
        {
            this.budget -= priceOfProduct;
        }

    }
}
