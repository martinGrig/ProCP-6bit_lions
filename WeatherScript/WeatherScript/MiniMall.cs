using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class MiniMall
    {
        private List<Shop> shops;
        private List<Position> positions; 
        private string name;
        private TimeSpan workingStartTime;
        private TimeSpan workingEndTime;
        private int capacity;
        private int floors;
        public MiniMall(string name, TimeSpan workingStartTime, TimeSpan workingEndTime, int capacity, int floors)
        {
            shops = new List<Shop>();
            positions = new List<Position>();
            this.name = name;
            this.workingStartTime = workingStartTime;
            this.workingEndTime = workingEndTime;
            this.capacity = capacity;
            this.floors = floors;
        }

        public bool AddStore(string name, int capacity, int popularity, double priceRange, DateTime busyHours, Category category)
        {
            Shop s = null;
            if (name != "" && capacity != 0 && priceRange != 0 && busyHours != null && category != Category.NOPURPOSE)
            {
                s = new Shop(name, capacity, popularity, priceRange, busyHours, category);
                if (!shops.Contains(s))
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

        // public bool changePosition()

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
