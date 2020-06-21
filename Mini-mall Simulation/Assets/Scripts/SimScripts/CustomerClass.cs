using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CustomerClass : MonoBehaviour
{
    [HideInInspector]
    public ShopSpawner mall = ShopSpawner.Instance;
    public int age;
    public string gender; //f/m
    public int freeTime;
    public double budget;
    public int[] preferencePositions; //new
    public int nrOfShopsToVisit; //set after setting free time
    private int currentShop = -1;
    private List<Category> existingShops;

    //vars used for calculations
    public double salesBoost;
    public double weekdayBoost;

    // Start is called before the first frame update
    void Start()
    {
        existingShops = new List<Category>();
        foreach (GameObject s in mall.shopInstances)
        {
            existingShops.Add(s.GetComponent<shopScript>().GetCategory());
        }
        this.age = SetAge();
        this.gender = SetGender();
        this.freeTime = SetFreeTime(salesBoost, weekdayBoost);
        this.budget = SetBudget(salesBoost); //to be calculated
        this.nrOfShopsToVisit = SetNrOfShopsToVisit(freeTime);
        this.preferencePositions = SetPreferences(nrOfShopsToVisit);
    }

    //private methods, for calculations
    private int SetAge() //fix percentages
    {
        double result = UnityEngine.Random.Range(0f, 1f);

        if (result <= 0.168)
        {
            return UnityEngine.Random.Range(15, 21);
        }
        else if (result > 0.168 && result <= 0.477)
        {
            return UnityEngine.Random.Range(21, 31);
        }
        else if (result > 0.477 && result <= 0.6525)
        {
            return UnityEngine.Random.Range(31, 41);
        }
        else if (result > 0.6525 && result <= 0.7765)
        {
            return UnityEngine.Random.Range(41, 51);
        }
        else if (result > 0.7765 && result <= 0.901)
        {
            return UnityEngine.Random.Range(51, 61);
        }
        else
        {
            return UnityEngine.Random.Range(60, 76);
        }
    }
    private string SetGender()
    {//for next iteration, make more research on preferences based on gender

        if (UnityEngine.Random.Range(0f,1f) <= 0.602)
        {
            return "f";
        }
        else
        {
            return "m";
        }
    }
    private int SetFreeTime(double salesBoost, double weekdayBoost) //based on sales/holidays, weekday => runs FIRST
    {
        double result = UnityEngine.Random.Range(0f,1f);

        if (result <= 0.66)
        {
            int freeTime = UnityEngine.Random.Range(30, 91); //30 mins to 1,5 hours
            double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
            return Convert.ToInt32(freeTimeModified);
        }
        else if (result > 0.66 && result <= 0.9)
        {
            int freeTime = UnityEngine.Random.Range(91, 181); // 1,5 hours to 3 hours
            double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
            return Convert.ToInt32(freeTimeModified);
        }
        else
        {
            int freeTime = UnityEngine.Random.Range(181, 301);// 3 hours to 5 hours
            double freeTimeModified = freeTime + freeTime * salesBoost + freeTime * weekdayBoost;
            return Convert.ToInt32(freeTimeModified);
        }
    }
    private double SetBudget(double salesBoost) //based of whether there are sales => runs AFTER SetFreeTime()
    {
        double result = UnityEngine.Random.Range(0f,1f);

        if (result <= 0.5)
        {
            int baseBudget = UnityEngine.Random.Range(0, 51);
            int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
            return boostedBudget;
        }
        else if (result > 0.5 && result <= 0.7)
        {
            return UnityEngine.Random.Range(51, 101);
        }
        else if (result > 0.7 && result <= 0.85)
        {
            int baseBudget = UnityEngine.Random.Range(101, 201);
            int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
            return boostedBudget;
        }
        else if (result > 0.85 && result <= 0.95)
        {
            int baseBudget = UnityEngine.Random.Range(201, 501);
            int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
            return boostedBudget;
        }
        else
        {
            int baseBudget = UnityEngine.Random.Range(501, 1001);
            int boostedBudget = Convert.ToInt32(baseBudget + baseBudget * salesBoost);
            return boostedBudget;
        }
    }

    private int SetNrOfShopsToVisit(int totalFreeTime) //based on free time
    {
        double timeSpentInShop = 30;
        int nrOfShopsToVisit = Convert.ToInt32(Math.Floor(totalFreeTime / timeSpentInShop)); //if the customer has time for 3.6 nr of shops, math.floor rounds 3.6 to 3, instead of 4
        return nrOfShopsToVisit;
    }

    private int[] SetPreferences(int nrOfPreferences) 
    {
        int counter = 0;
        preferencePositions = new int[nrOfPreferences]; 
        while (counter < nrOfPreferences)
        {
            
            double result = UnityEngine.Random.Range(0f, 1.15f); //add no purpose and adjust %

            double clothing;
            double food;
            double bookStore;
            double entertainment;
            double cafe;

            if(gender.Equals("f"))
            {
                clothing = 0.32;
                food = clothing + 0.20;
                bookStore = food + 0.18;
                entertainment = bookStore + 0.14;
                cafe = entertainment + 0.16;
            }
            else
            {
                clothing = 0.19;
                food = clothing + 0.32;
                bookStore = food + 0.15;
                entertainment = bookStore + 0.23;
                cafe = entertainment + 0.11;
            }



            if (result <= clothing && existingShops.Contains(Category.CLOTHES)) //clothing, 26% - 2
            {
                List<int> positionsToChooseFrom = new List<int>();                
                foreach (GameObject s in mall.shopInstances)
                {
                    if(s.GetComponent<shopScript>().GetCategory() == Category.CLOTHES)
                    {
                        positionsToChooseFrom.Add(s.GetComponent<shopScript>().positionID);
                    }
                }
                preferencePositions[counter] = positionsToChooseFrom[UnityEngine.Random.Range(0, positionsToChooseFrom.Count)];
                counter++;
            }
            else if (result > clothing && result <= food && existingShops.Contains(Category.FOOD))  //food, 19% 
            {
                List<int> positionsToChooseFrom = new List<int>();                
                foreach (GameObject s in mall.shopInstances)
                {
                    if(s.GetComponent<shopScript>().GetCategory() == Category.FOOD)
                    {
                        positionsToChooseFrom.Add(s.GetComponent<shopScript>().positionID);
                    }
                }
                preferencePositions[counter] = positionsToChooseFrom[UnityEngine.Random.Range(0, positionsToChooseFrom.Count)];
                counter++;
            }
            else if (result > food && result <= bookStore && existingShops.Contains(Category.BOOKSTORE)) //bookstore, 15%
            {
                List<int> positionsToChooseFrom = new List<int>();                
                foreach (GameObject s in mall.shopInstances)
                {
                    if(s.GetComponent<shopScript>().GetCategory() == Category.BOOKSTORE)
                    {
                        positionsToChooseFrom.Add(s.GetComponent<shopScript>().positionID);
                    }
                }
                preferencePositions[counter] = positionsToChooseFrom[UnityEngine.Random.Range(0, positionsToChooseFrom.Count)];
                counter++;
            }
            else if (result > bookStore && result <= entertainment && existingShops.Contains(Category.ENTERTAINMENT)) //entertainment, 14%
            {
                List<int> positionsToChooseFrom = new List<int>();                
                foreach (GameObject s in mall.shopInstances)
                {
                    if(s.GetComponent<shopScript>().GetCategory() == Category.ENTERTAINMENT)
                    {
                        positionsToChooseFrom.Add(s.GetComponent<shopScript>().positionID);
                    }
                }
                preferencePositions[counter] = positionsToChooseFrom[UnityEngine.Random.Range(0, positionsToChooseFrom.Count)];
                counter++;
            }
            else if (result > entertainment && result <= cafe && existingShops.Contains(Category.CAFE)) //cafe, 13%
            {
                List<int> positionsToChooseFrom = new List<int>();                
                foreach (GameObject s in mall.shopInstances)
                {
                    if(s.GetComponent<shopScript>().GetCategory() == Category.CAFE)
                    {
                        positionsToChooseFrom.Add(s.GetComponent<shopScript>().positionID);
                    }
                }
                preferencePositions[counter] = positionsToChooseFrom[UnityEngine.Random.Range(0, positionsToChooseFrom.Count)];
                counter++;
            }
            else if(result > cafe) //without purpose, 13%
            {
                
                preferencePositions[counter] = GetNoPurposeShop();
                counter++;
            }
        }
        return preferencePositions;
    }

    public int GetNoPurposeShop()
    //a new customer object uses this method. the method returns a "random" shop,
    //based on position popularity. the returned shop gets added to the customer's preferences list
    {
        double result = UnityEngine.Random.Range(0f,1f);

        if (result <= 0.30) //position 1, 30 %
        {
            return 1;
        }
        else if (result > 0.30 && result <= 0.55)  //position 2, 25 %
        {
            return 2;
        }
        else if (result > 0.55 && result <= 0.75) //position 3, 20%
        {
            return 3;
        }
        else if (result > 0.75 && result <= 0.90) //position 4, 15%
        {
            return 4;
        }
        else //position 5, 10%
        {
            return 5;
        }
    }

    

    //public methods, usable after the Customer instance has been created
    public int GetAge()
    {
        return age;
    }
    public string GetGender()
    {
        return gender;
    }
    public int GetFreeTime()
    {
        return freeTime;
    }
    public double GetBudget()
    {
        return budget;
    }
    public int[] GetPreferences()
    {
        return this.preferencePositions;
    }
    public void BuySomething(double priceOfProduct)
    {
        this.budget -= priceOfProduct;
    }

    public int GetShop()
    {
        currentShop++;
        if (currentShop < preferencePositions.Length)
        {
            return preferencePositions[currentShop];
        }
        currentShop = -1;
        return 0;
    }

}
