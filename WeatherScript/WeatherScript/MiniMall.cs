using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class MiniMall
    {
        private List<Shop> shops = new List<Shop>();

        public MiniMall()
        {

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
