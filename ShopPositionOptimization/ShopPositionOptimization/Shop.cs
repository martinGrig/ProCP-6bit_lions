using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Shop
    {
        private static int id = 0;
        private int shopID;
        private string name;
        private double income;   
        private bool hasSale;
        //private int capacity; no need for that
        private int popularity;
        private double priceRange;
        private DateTime busyHours;    
        private Category category;
        private List<Customer> customers;
        
        
        public Shop(string name, int popularity, double priceRange, DateTime busyHours, Category category)
        {
            this.shopID = Shop.id++;
            this.name = name;
            this.income = 0;
            this.hasSale = false;
            this.popularity = popularity;
            this.priceRange = priceRange;
            this.busyHours = busyHours;
            this.category = category;
            customers = new List<Customer>();

        }


        public void onSale()
        {
            hasSale = true;
        }
        public void AddCustomer(Customer c)
        {
            customers.Add(c);
        }
        
        public string GetName()
        {
            return name;
        }
        public double GetIncome()
        {
            return income;
        }
        public Category GetCategory()
        {
            return category;
        }
       public List<Customer> GetCustomers()
        {
            return this.customers;
        }

    }
}
