using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    private int shopID;
    private string shopName;
    private float revenue;
    private bool hasSale;
    private int popularity;
    private float priceRange;
    private Time busyHours;
    private Category category;
    private List<CustomerClass> customers;


    public ShopItem(int ShopID, string ShopName, int Revenue)
    {
        shopID = ShopID;
        shopName = ShopName;
        revenue = Revenue;
    }

    private void Populate()
    {
        this.transform.GetChild(0).GetComponent<TextMesh>().text = shopID.ToString();
        this.transform.GetChild(2).GetComponent<TextMesh>().text = shopName;
        this.transform.GetChild(4).GetComponent<TextMesh>().text = revenue.ToString();
    }
}
