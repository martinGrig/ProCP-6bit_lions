using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CustomerClass : MonoBehaviour
{
    public int age;
    public string gender; //f/m
    public int freeTime;
    public double budget;
    public Category[] preferences; //new
    public int nrOfShopsToVisit; //set after setting free time
    public shopSpawner mall;


    //vars used for calculations
    private double salesBoost;
    private double weekdayBoost;

    // Start is called before the first frame update
    void Start()
    {
        this.age = SetAge();
        this.gender = SetGender();
        this.freeTime = SetFreeTime(salesBoost, weekdayBoost);
        this.budget = SetBudget(salesBoost); //to be calculated
        this.nrOfShopsToVisit = SetNrOfShopsToVisit(freeTime);
        this.preferences = SetPreferences(nrOfShopsToVisit);
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
    private double SetBudget(double salesBoost) //based of wether there are sales => runs AFTER SetFreeTime()
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
    private Category[] SetPreferences(int nrOfPreferences) //make it an array,using persentages, based on budget
    {
        Category[] preferences = new Category[nrOfPreferences]; //add a "nothing" category

        for (int i = 0; i < nrOfPreferences; i++)
        { //should make it impossible to add a category more than once
            double result = UnityEngine.Random.Range(0f,1f); //add no purpose and adjust %

            if (result <= 0.26) //clothing, 26% , && !preferences.Contains(Category.CLOTHES)
            {
                preferences[i] = Category.CLOTHES;
            }
            else if (result > 0.26 && result <= 0.45)  //food, 19%
            {
                preferences[i] = Category.FOOD;
            }
            else if (result > 0.45 && result <= 0.60) //bookstore, 15%
            {
                preferences[i] = Category.BOOKSTORE;
            }
            else if (result > 0.60 && result <= 0.74) //entertainment, 14%
            {
                preferences[i] = Category.ENTERTAINMENT;

            }
            else if (result > 0.74 && result <= 0.87) //cafe, 13%
            {
                preferences[i] = Category.CAFE;

            }
            else  //jewelry, ~10%
            {
                preferences[i] = Category.NOPURPOSE;

            }
        }
        return preferences;
    }

    public Category GetNoPurposeShop()
    //a new customer object uses this method. the method returns a "random" shop,
    //based on position popularity. the returned shop gets added to the customer's preferences list
    {
        double result = UnityEngine.Random.Range(0f,1f);

        if (result <= 0.30) //position 1, 30 %
        {
            return mall.shops[0].GetComponent<shopScript>().GetCategory();
        }
        else if (result > 0.30 && result <= 0.55)  //position 2, 25 %
        {
            return mall.shops[1].GetComponent<shopScript>().GetCategory();
        }
        else if (result > 0.55 && result <= 0.75) //position 3, 20%
        {
            return mall.shops[2].GetComponent<shopScript>().GetCategory();
        }
        else if (result > 0.75 && result <= 0.90) //position 4, 15%
        {
            return mall.shops[3].GetComponent<shopScript>().GetCategory();

        }
        else //position 5, 10%
        {
            return mall.shops[4].GetComponent<shopScript>().GetCategory();

        }
    }

    public void AdjustCustomerPreferences(Category addition) //adjusting preferences based on Shop popularity and Position popularity
    {//shop popularity not necessary for this iteration, since we are using 1 shop of every type; shop type popularity is basically 
     //allready set in the SetPreferences method
        int count = 0;
        int countycount = 0;
        Category[] toBeAdded = new Category[preferences.Length];
        for (int i = 0; i < preferences.Length; i++)
        {
            if (preferences[i] == Category.NOPURPOSE)
            {
                toBeAdded[count] = GetNoPurposeShop();
                count++;
            }
        }
        Category[] temp = new Category[toBeAdded.Length + preferences.Length];
        for (int i = 0; i< toBeAdded.Length; i++)
		{
            temp[i] = toBeAdded[i];//just ignore the "NOPURPOSE" type
		}

        for (int i = toBeAdded.Length; i < temp.Length; i++)
        {
            temp[i] = preferences[countycount];     
            countycount++;
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
    public Category[] GetPreferences()
    {
        return this.preferences;
    }
    public void BuySomething(double priceOfProduct)
    {
        this.budget -= priceOfProduct;
    }

}
