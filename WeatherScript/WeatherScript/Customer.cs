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
        //fields
        private static int id = 0;
        private int customerID;
        private int age;
        private string gender; //f/m
        private int freeTime;
        private double budget;
        private Category[] preferences; //new
        private int nrOfShopsToVisit; //set after setting free time


        //vars used for calculations
        private double salesBoost;
        private double weekdayBoost;
        private double freeTimeBoost;

        //constructor
        public Customer()
        {
            this.customerID = Customer.id++;
            this.age = SetAge();
            this.gender = SetGender();
            this.freeTime = SetFreeTime(salesBoost, weekdayBoost);
            this.budget = SetBudget(freeTimeBoost); //to be calculated
            this.nrOfShopsToVisit = SetNrOfShopsToVisit(freeTime);
            this.preferences = SetPreferences(nrOfShopsToVisit);
        }

        //private methods, for calculations
        private int SetAge() //fix percentages
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
        private string SetGender() //no change...
        {//do we need gender if we are not using it for anything?

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
        private int SetFreeTime(double salesBoost, double weekdayBoost) //based on sales/holidays, weekday, day of week too => runs FIRST
        {
            //set free time boost for different cases
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.66)
            {
                int freeTime = random.Next(30, 91); //30 mins to 1,5 hours
                double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
                return Convert.ToInt32(freeTimeModified);
            }
            else if (result > 0.66 && result <= 0.9)
            {
                int freeTime = random.Next(91, 181); // 1,5 hours to 3 hours
                double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
                return Convert.ToInt32(freeTimeModified);
            }
            else
            {
                int freeTime = random.Next(181, 301);// 3 hours to 5 hours
                double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
                return Convert.ToInt32(freeTimeModified);
            }
        }
        private double SetBudget(double salesBoost) //based of wether there are sales => runs AFTER SetFreeTime()
        {
            Random random = new Random();
            double result = random.NextDouble();

            if (result <= 0.5)
            {
                int baseBudget = random.Next(0, 51);
                int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
                return boostedBudget;
            }
            else if (result > 0.5 && result <= 0.7)
            {
                return random.Next(51, 101);
            }
            else if (result > 0.7 && result <= 0.85)
            {
                int baseBudget = random.Next(101, 201);
                int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
                return boostedBudget;
            }
            else if (result > 0.85 && result <= 0.95)
            {
                int baseBudget = random.Next(201, 501);
                int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
                return boostedBudget;
            }
            else
            {
                int baseBudget = random.Next(501, 1001);
                int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
                return boostedBudget;
            }
        }

        private int SetNrOfShopsToVisit(int totalFreeTime) //based on free time
        {
            Random r = new Random();
            double timeSpentInShop = totalFreeTime * r.NextDouble();
            int nrOfShopsToVisit = Convert.ToInt32(Math.Floor(totalFreeTime / timeSpentInShop)); //if the customer has time for 3.6 nr of shops, math.floor rounds 3.6 to 3, instead of 4
            return nrOfShopsToVisit;
        }
        private Category[] SetPreferences(int nrOfPreferences) //make it an array,using persentages, based on budget, should figure out how much time one shopping will last
        {
            Category[] preferences = new Category[nrOfPreferences];

            for (int i = 0; i < nrOfPreferences; i++)
            { //should make it impossible to add a category more than once

                Random random = new Random();
                double result = random.NextDouble();

                if (result <= 0.26) //clothing, 26% , && !preferences.Contains(Category.CLOTHES)
                {
                    preferences[i] = Category.CLOTHES;
                }
                else if (result > 0.26 && result <= 0.45)  //food, 19%
                {
                    preferences[i] = Category.FOOD;
                }
                else if (result > 0.45 && result <= 0.60) //bookstore, 15%
                {
                    preferences[i] = Category.BOOKSTORE;
                }
                else if (result > 0.60 && result <= 0.74) //entertainment, 14%
                {
                    preferences[i] = Category.ENTERTAINMENT;

                }
                else if (result > 0.74 && result <= 0.87) //cafe, 13%
                {
                    preferences[i] = Category.CAFE;

                }
                else  //jewelry, ~10%
                {
                    preferences[i] = Category.JEWLERY;

                }
            }
            return preferences;
        }

        //public methods, usable after the Customer instance has been created
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
            return freeTime;
        }
        public double GetBudget()
        {
            return budget;
        }
        public Category[] GetPreferences()
        {
            return this.preferences;
        }
        public void BuySomething(double priceOfProduct)
        {
            this.budget -= priceOfProduct;
        }

    }
}
