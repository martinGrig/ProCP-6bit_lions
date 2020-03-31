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
        private double multiplier;
        private int capacity;

        public Position(double multiplier, Size size)
        {
            this.id = ID++;
            this.multiplier = SetPositionPopularity();
            this.size = size;
        }
        public void ChooseShop(Shop shop)
        {
            this.shop = shop;
        }
        public double SetPositionPopularity()
        {
            return 0.0;
        }
    }
}
