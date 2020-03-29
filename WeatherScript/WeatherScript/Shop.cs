using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Shop
    {
        private static int id = 0;
        private string name;
        private double income;   
        private bool hasSale;
        private int capacity;
        private int popularity;
        private double priceRange;
        private DateTime busyHours;    
        private Category category;
        private List<Customer> customers;
        
        
        public Shop(string name, int capacity, int popularity, double priceRange, DateTime busyHours, Category category)
        {
            this.count = 0;
            this.id++;
            this.name = name;
            this.income = 0;
            this.hasSale = false;
            this.capacity = capacity;
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
        public bool isFull()
        {
            if (capacity == customers.Count)
            {
                return true;
            }
            return false;
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
        public int GetCapacity()
        {
            return capacity;
        }

    }
}
