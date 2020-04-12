using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotScript : MonoBehaviour
{
    private GameObject shop;

    public void SetShop(GameObject shop)
    {
        this.shop = shop;
        Instantiate(shop, gameObject.transform.position, Quaternion.identity);
    }
}
