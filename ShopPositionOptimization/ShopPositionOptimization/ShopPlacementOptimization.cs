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
            foreach  (ShopPlacement sp in shopPlacements)
            {
                shopPositions.Add(sp.PositionID, sp.ShopName);
            }
        }

        public void MakeRollercoaster(List<Dictionary<string, int>> list) //Create the switch statement to calculate and compare what shop 
        {                                                                  //made the most at what position and save them with their best ProfitPerPosition


        }

        public Dictionary<int, string> OptimizeShopPlacement()
        {
            //get the array of json objects, it is sorted by positionID

            double[] shopRevenues = 5;      //This shopRevenue array represents the highest income for every POSITION. They are always 5.
            List<string> shopNames = 5;     //shopName array saves the name of the most profitable shop for each POSITION. 

            if (shopResults.Lenght >= 15)      //At least 15, because the research showed that we need at least 3 simulation for our algorithm to run properly and deliver.
            {

                for (int i = 0; i < shopResults.Length; i++)
                {
                    switch (shopResults[i].positionID)//This switch statement has to return dictionary in all cases. Otherwise VS will complain.
                    {
                        case 1: //position 1
                            if (shopRevenues[0] < shopResults[i].revenue)
                            {
                                shopRevenues[0] = shopResults[i].revenue;
                                shopNames.ElementAt(0) = shopResults[i].shopname;
                            }
                            break;

                        case 2: //position 2...
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


                        default:
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
            }
            else//Rollercoaster
            {

                //here run the simulation on random(3, 5) times and call this function again in order to get to the possitive if statement
                //make assoc. array position->shopName(same as the one mentioned above, but since the function does not get into the if 
                //statement we can reuse the reserved memory for this else statement)
                //for(i = 0; i < random(3, 5); i++;)
                //{
                //runSimulation()
                //stopSimulation()
                //Rhe first argument can be either 0 or i. That has to be tested.
                //ReorderDictionaty(i, 5) reorder the shops for the next simulation and runit again as many times as the for loop demands.
                //}
                //this.OptimizeShopPlacement();
                //use the ReorderMethod 5 times

            }

            return shopPositions;

        }                              // We can use just 0, 5, because we have only 5 positions.
        public void ReorderDictionary(int oldIndex, int newIndex)   //we  run 5 simulations and every other simulation we execute the reorder dictionary method which will reorder the positions
        {
            
            var oldDictionary = new Dictionary<int, string>(); 
            oldDictionary.Add(1, "shop1");
            oldDictionary.Add(2, "shop2");
            oldDictionary.Add(3, "shop3");
            oldDictionary.Add(4, "shop4");
            oldDictionary.Add(5, "shop5");//fill the dictioanaryy with values fro the gui

            var movedItem = oldDictionary[oldIndex];//remove the first value of the dictioanarry and place it ina var for later use
            oldDictionary.Remove(oldIndex);

            var newDictionary = new Dictionary<int, string>();//Initialize the new dictionary

            var offset = 0;
            for (var i = 0; i < oldDictionary.Count; i++)//loop through all elements of the dictioanry
            {
                if (i + 1 == newIndex)//if statement to check if you are at the last element and if yes -> you add the stored var from above.
                {
                    newDictionary.Add(i, movedItem);
                    offset = 1;
                }
                var oldEvent = oldDictionary[oldDictionary.Keys.ElementAt(i)];
                newDictionary.Add(i + offset, oldEvent);//add the next event to the previous position
            }
            //not sure if that is going to break the appp, but it catches the exception array.IndexOutOFBounds
            if (newIndex > oldDictionary.Count)
            {
                newDictionary.Add(oldDictionary.Count + 1, movedItem);
            }
        }
        //from here
        /*
            var array1 = new Dictionary<int, string>(); //original array, takes positions and shops from ui; never changes throughout the code below!
            array1.Add(1, "shop1");
            array1.Add(2, "shop2");
            array1.Add(3, "shop3");
            array1.Add(4, "shop4");
            array1.Add(5, "shop5");

            var array2 = new Dictionary<int, string>(); //iterative array, empty in the begnning; changes each loop, using the positions of array1

        //run sim once with array1 because we also want to use the current positioning for the calculations. this avoids going through the loop below once
        

        for (int i = 0; i <= 3; i++)   //loops 4 times. uses array1 as a map and array2 for switching the placements. 
        {                
            array2[1+i] = array1[5]; //always begin with copying the last shop from array1 into the first position of array2

            int pivot1=1;  //pointer for array1; always points to the shop we are copying from array1
            int pivot2=i+2;  //pointer for array2; always points to the position we are BEGINNING with

            for (int j = pivot2; j <= 5 ; j++) //from pivot2 till the end of the array
            {
                array2[j] = array1[pivot1];
                pivot1++;
            }
            if(pivot2>2){ //avoids array out of bounds exeption and starts copying shops to the beginning of array2
                for (int a = 1; a <=pivot2-2; a++) //from the beginning of array2 till pivot2, but also skipping the first switching of places
                { 
                    array2[a] = array1[pivot1];
                    pivot1++;
                }
            }
            //runSim(); //use array2 for this
        }
        OptimizeShopPlacement();
        */

    }
}
