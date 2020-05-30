using System;
using System.Collections.Generic;
using System.Text;
using WeatherScript;

namespace ShopPositionOptimization
{
    class ShopPlacementOptimization
    {
        private Position[] positions;
        private Result[] shopResults;
        private Dictionary<string, int> shopPositions; //Shop, Position
        private Dictionary<int, double> profitsPerPosition; //Position, Profit
        public ShopPlacementOptimization()
        {
            positions = new Position[5];
            profitsPerPosition = new Dictionary<int, double>();
            shopResults = new Result[positions.Length];
        }
        public void MakeRollercoaster(List<Dictionary<string, int>> list) //Create the switch statement to calculate and compare what shop 
        {                          //made the most at what position and save them with their best ProfitPerPosition
            switch (profitsPerPosition)
            {
                default:
                    break;
            }
        }

        public Dictionary<int, double>  OptimizeShopPlacement(Dictionary<string, int> oldProfits)
        {
            

            return new Dictionary<int, double>();
        }

         
    }
}
