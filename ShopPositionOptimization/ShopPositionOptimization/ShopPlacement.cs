using System;
using System.Collections.Generic;
using System.Text;

namespace ShopPositionOptimization
{
    class ShopPlacement
    {
        public int ResultID { get; set; }
        public int PositionID { get; set; }
        public string ShopName { get; set; }
        public double Income { get; set; }

        public ShopPlacement(int resultID, int positionID, string shopName, double income)
        {
            this.ResultID = resultID;
            this.PositionID = PositionID;
            this.ShopName = shopName;
            Income = income;
        }


    }
}
