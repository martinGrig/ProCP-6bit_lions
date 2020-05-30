using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Position
    {
        private static int ID = 0;
        private int id;
        private Shop shop;
        private Size size;
        private double popularity;
        private int capacity;
        private List<Customer> customers;

        public Position(double popularity, Size size)
        {
            this.id = ID++;
            this.popularity = popularity;
            this.size = size;
            customers = new List<Customer>();
        }
        public void ChooseShop(Shop shop)
        {
            this.shop = shop;
        }
        public void SetPositionPopularity(double newPop)
        {
           this.popularity = newPop;
        }
        public Shop GetShopOnThisPosition()
        {
            return this.shop;
        }

        public double GetPopularity()
        {
            return this.popularity;
        }
        public bool isFull()
        {
            this.customers = this.shop.GetCustomers();
            if (capacity == customers.Count)
            {
                return true;
            }
            return false;
        }
    }
}
