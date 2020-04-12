using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopSpawner : MonoBehaviour
{
    public GameObject[] customers;
    public GameObject[] spots;
    public GameObject[] shops;
    private Category[] categories = new Category[5];
    private Vector3 customerSpawn;
    public GridTester gT;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        categories[0] = Category.FOOD;
        categories[1] = Category.CLOTHES;
        categories[2] = Category.BOOKSTORE;
        categories[3] = Category.ENTERTAINMENT;
        categories[4] = Category.CAFE;
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            shops[i].transform.localScale = spots[i].transform.lossyScale;
            shops[i] = Instantiate(shops[i], spots[i].transform.position, Quaternion.identity);
            shops[i].GetComponent<shopScript>().SetCategory(categories[i]);
        }
        for (int i = 0; i < customers.Length; i++)
        {
            customerSpawn = new Vector3(0f, 6f, 0f);
            customers[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            customers[i] = Instantiate(customers[i], customerSpawn, Quaternion.identity);
        }
    }

    private void Update()
    {
        if(started == false)
        {
            gT.StartTicking();
            started = true;
        }
    }

    public GameObject RandomShop()
    {
        return shops[Random.Range(0, shops.Length)];
    }
}
