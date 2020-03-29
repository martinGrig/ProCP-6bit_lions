using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherScript
{
    class Position
    {
        private static int id = 0;
        private Shop shop;
        private Size size;
        private int multiplier;
        private int capacity;

        public Position(double multiplier,Size size)
        {
            this.id++;
            this.multiplier;
            this.size = size;
        }
        public void ChooseShop(Shop shop)
        {
           this.shop = shop;
        }
    }
}
