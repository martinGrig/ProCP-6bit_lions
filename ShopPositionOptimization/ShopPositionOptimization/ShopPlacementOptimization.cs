using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WeatherScript;
using System.Linq;

namespace ShopPositionOptimization
{
    class ShopPlacementOptimization
    {
        
        private Position[] positions;
        private Result[] shopResults;
        private Dictionary<int, string> shopPositions; //Position, shopName
        private Dictionary<int, double> profitsPerPosition; //Position, Profit
        private List<Object> positionShopResultList;

        private List<ShopPlacement> shopPlacements;

        public ShopPlacementOptimization()
        {
            positions = new Position[5];
            profitsPerPosition = new Dictionary<int, double>();
            shopResults = new Result[positions.Length];
            shopPlacements = new List<ShopPlacement>();

        }
        public void PopulateShopPositionsDictionary()
        {
            foreach(ShopPlacement sp in shopPlacements)
            {
                shopPositions.Add(sp.PositionID, sp.ShopName);


            }
        }

        public void MakeRollercoaster(List<Dictionary<string, int>> list) //Create the switch statement to calculate and compare what shop 
        {                                                                  //made the most at what position and save them with their best ProfitPerPosition
            
            
        }

        public Dictionary<int, string>  OptimizeShopPlacement(string WhoKnowsWhat)
        {
            Sort(shopResults, IComparer);  //sort by position, not done yet

            double[] shopRevenues = 5;
            List<string> shopNames = 5;

            if (shopResults.Lenght >= 15)
            {

                for (int i = 0; i < shopResults.Length; i++)
                {
                    switch (shopResults[i].positionID)
                    {
                        case 1:
                            if (shopRevenues[0] < shopResults[i].revenue)
                            {
                                shopRevenues[0] = shopResults[i].revenue;
                                shopNames.ElementAt(0) = shopResults[i].shopname;                                
                            }
                            break;

                        case 2:
                            if (shopRevenues[1] < shopResults[i].revenue && !shopNames.Contains(shopResults[i].shopName))
                            {
                                shopRevenues[1] = shopResults[i].revenue;
                                shopNames.ElementAt(1) = shopResults[i].shopname;
                            }
                            break;


                        case 3:
                            if (shopRevenues[2] < shopResults[i].revenue && !shopNames.Contains(shopResults[i].shopName))
                            {
                                shopRevenues[2] = shopResults[i].revenue;
                                shopNames.ElementAt(2) = shopResults[i].shopname;
                            }
                            break;


                        case 4:
                            if (shopRevenues[3] < shopResults[i].revenue && !shopNames.Contains(shopResults[i].shopName))
                            {
                                shopRevenues[3] = shopResults[i].revenue;
                                shopNames.ElementAt(3) = shopResults[i].shopname;
                            }
                            break;


                        case 5:
                            if (shopRevenues[4] < shopResults[i].revenue && !shopNames.Contains(shopResults[i].shopName))
                            {
                                shopRevenues[4] = shopResults[i].revenue;
                                shopNames.ElementAt(4) = shopResults[i].shopname;
                            }
                            break;
                    }
                }

            for (int i = 0; i < shopNames.Count; i++)
            {
                shopPositions.Add(i + 1, shopNames.ElementAt(i));
            }

                    
            //////////////////////////////////////////
            //shopPositions.Add(1, row.shopname);

            //case position = 2
            //if (max2<row.revenue)
            //max2=row.revenue
            //shop2 = row.shopname
            //shopPositions.Add(2, row.shopname);

            //case position = 3
            //if (max3<row.revenue)
            //max3=row.revenue
            //shop3 = row.shopname
            //shopPositions.Add(3, row.shopname);

            //case position = 4
            //if (max3<row.revenue)
            //max3=row.revenue
            //shop3 = row.shopname
            //shopPositions.Add(4, row.shopname);

            //case position = 5
            //if (max3<row.revenue)
            //max3=row.revenue
            //shop3 = row.shopname
            //shopPositions.Add(5, row.shopname);


            //}
            //else run 3 simulations
            //put stuff in dictionary

            //second way

            //double max1, max2, max3, max4, max5;
            //string shop1, shop2, shop3...

            //if (shopResults.Lenght >= 5)
            //{
            //for (int i = 0; i < positionShopResultList.Count; i++)
            //{
            //    for(int j = 1; j < 6; j++){
            //    if(){}
            //}
            //}
            //for i=0; i<shopResults.Length; i++ // this for have to loop through all the results returned from the database

            //switch(shopResults[i].positionId) // go through all the results and compare the revenue to see which shop is most suitable for what possition

            //case position = 1
            //if (max1<row.revenue)
            //max1=row.revenue //change the highest income for position 1
            //shop1 = row.shopname // change the highest income shop for position 1

            List<int> revenuetaOne = new List<int>();
            for (int i = 0; i < shopPlacements.Count; i++)
            {

                foreach (KeyValuePair<int, string> entry in shopPositions)
                {
                    if (entry.Key == 1 && entry.Value != row.shopname && revenuetaOne[i--] < shopPlacements[i] )
                    {
                        //max1=row.revenue
                        //shop1 = row.shopname
                        revenueta.Add(shopPlacement[i].Income);
                        revenuetaOne.Sort();
                        shopPositions.Add(1, )

                    }
                    if (entry.Key == 2 && entry.Value != row.shopname)
                    {
                        //max1=row.revenue
                        //shop1 = row.shopname
                    }
                    if (entry.Key == 3 && entry.Value != row.shopname && max3 < row.revenue)
                    {
                        //max1=row.revenue
                        //shop1 = row.shopname
                    }
                    if (entry.Key == 4 && entry.Value != row.shopname && max4 < row.revenue)
                    {
                        //max1=row.revenue
                        //shop1 = row.shopname
                    }
                    if (entry.Key == 5 && entry.Value != row.shopname && max5 < row.revenue)
                    {
                        //max1=row.revenue
                        //shop1 = row.shopname
                    }
                    

                }
            }


            return shopPositions;
        }

         
    }
}
