using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class MiniMall
    {
        private List<Shop> shops = new List<Shop>();
        private string name;
        private DateTime workingTime;
        private int capacity;
        private int floors;
        public MiniMall(string name, DateTime workingTime, int capacity, int floors)
        {
            this.name = name;
            this.workingTime = workingTime;
            this.capacity = capacity;
            this.floors = floors;
        }

        public bool AddStore(string name, int capacity, int popularity, double priceRange, DateTime busyHours, Category category)
        {
            Shop s = null;
            if (name != "" && capacity != 0 && priceRange != 0 && busyHours != null && category != null)
            {
                s = new Shop(name, capacity, popularity, priceRange, busyHours, category);
                if (shops.Contains(s))
                {
                    shops.Add(s);
                    return true;
                }
                return false;
            }
            else
            {
                throw new Exception("Please fill in field");
                return false;
            }

        }

        public double GetAllIncome()
        {
            double allIncome = 0;
            foreach (Shop item in shops)
            {
                allIncome += item.GetIncome();
            }
            return allIncome;
        }
        public List<Shop> GetShops()
        {
            return shops;
        }
    }
}
