using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Shop
{

    public string Name;
    public string AverageSpending;
    public string BusyHours;
    public string Category;

    public Shop(string Name, string AverageSpending, string BusyHours, string Category)
    {
        this.Name = Name;
        this.AverageSpending = AverageSpending;
        this.BusyHours = BusyHours;
        this.Category = Category;
    }

}
