using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.Linq;

public class ShopSpawner : MonoBehaviour
{
    public GameObject customerPrefab;
    public GameObject shopPrefab;
    public GameObject[] spots;
    public GameObject[] shopInfo;
    public TextMeshProUGUI totalRevenueLabel;
    public TextMeshProUGUI totalCustomersLabel;
    public TextMeshProUGUI formName; //edit form name
    public TMP_InputField createSpending, createName, createBusy;
    public TMP_Dropdown createCategory;
    public ScrollbarController sc;

    public List<Shop> shops;
    //public string[] shopNames;
    //public Category[] categories = new Category[6];
    public TextMeshProUGUI[] shopLabels;
    public Settings settings;
    public UnityEngine.UI.Image[] pencils;
    public Transform editWindowContent;
    public GridTester gT;
    public bool swapping;
    public GameObject[] shopOptimizationList; // sorting shops in the optimization UI

    //variables which are affected by the settings
    private float priceMultiplier = 1;
    private float customerMultiplier = 1;

    private Vector3 customerSpawn;
    private bool started = false;
    private double totalRevenue;
    private int totalCustomers;
    private GameObject swap = null;
    private int toSwap;

    [HideInInspector] // Hides var below
    public GameObject[] customers;
    [HideInInspector] // Hides var below
    public GameObject[] shopInstances;
    [HideInInspector] // Hides var below
    public List<Settings> presets = new List<Settings>();
    public List<GameObject> remainingShops;

    public static ShopSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //categories[0] = Category.EXIT;
        //categories[1] = Category.CLOTHES;
        //categories[2] = Category.ENTERTAINMENT;
        //categories[3] = Category.CAFE;
        //categories[4] = Category.BOOKSTORE;
        //categories[5] = Category.FOOD;

    }

    //The InstantiateShops() script is called from within the UIHandler, after the shops have been loaded from the database
    public void InstantiateShops()
    {
        shopInstances = new GameObject[6];

        //Instantiate the Exit
        shopInstances[0] = Instantiate(shopPrefab, spots[0].transform.position, Quaternion.identity);
        shopInstances[0].GetComponent<shopScript>().SetPosition(0);
        shopInstances[0].GetComponent<shopScript>().SetCategory(Category.EXIT);
        shopInstances[0].GetComponent<shopScript>().shopName = "Exit";
        shopLabels[0].transform.GetComponent<TextMeshProUGUI>().text = "Exit";

        //Instantiate the other shops in the possible spots
        for (int i = 1; i < spots.Length; i++)
        {
            //Parse the category from a string (in the shop class), to a Category enum type
            Category category = (Category)System.Enum.Parse(typeof(Category), shops[i - 1].Category);
            // Instantiate the Shop into his spot and set the necessary values for its shopScript
            shopInstances[i] = Instantiate(shopPrefab, spots[i].transform.position, Quaternion.identity);
            shopInstances[i].GetComponent<shopScript>().SetPosition(i);
            shopInstances[i].GetComponent<shopScript>().SetCategory(category);
            shopInstances[i].GetComponent<shopScript>().shopName = shops[i - 1].Name;
            shopInstances[i].GetComponent<shopScript>().busyHours = shops[i - 1].BusyHours;
            shopInstances[i].GetComponent<shopScript>().averageSpending = float.Parse(shops[i - 1].AverageSpending);
            // Setting the shop label in the mall map
            shopLabels[i].transform.GetComponent<TextMeshProUGUI>().text = shops[i - 1].Name;
            // Adding the Edit window to the shopScript
            shopInstances[i].GetComponent<shopScript>().AddEditWindow(editWindowContent);
            // Setting the pencil on the top-right corner, for editing a shop
            shopInstances[i].GetComponent<shopScript>().SetPencil(pencils[i]);
            // Setting the TMP Labels in the ShopResult tab
            shopInstances[i].GetComponent<shopScript>().SetText(shopInfo[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>(), shopInfo[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>(), shopInfo[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());

            // Setting the position, name, category for the shopOptimizationList
            shopOptimizationList[i - 1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i.ToString();
            shopOptimizationList[i - 1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shops[i - 1].Name;
            shopOptimizationList[i - 1].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = category.ToString();
            //Doing some diferentiation for each shop
            shopInstances[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            shopInstances[i].transform.localScale = spots[i].transform.lossyScale;
        }

        if (shops.Count > spots.Length - 1)
        {
            for (int i = spots.Length; i <= shops.Count; i++)
            {
                GameObject newShop = Instantiate(shopPrefab, new Vector3(1000f, 1000f), Quaternion.identity);
                remainingShops.Add(newShop);
                newShop.GetComponent<shopScript>().AddEditWindow(editWindowContent);
                newShop.GetComponent<shopScript>().SetPosition(i);
                remainingShops[i-6].GetComponent<shopScript>().shopName = shops[i - 1].Name;
                remainingShops[i-6].GetComponent<shopScript>().busyHours = shops[i - 1].BusyHours;
                Category category = (Category)System.Enum.Parse(typeof(Category), shops[i - 1].Category);
                newShop.GetComponent<shopScript>().SetCategory(category);
                newShop.GetComponent<shopScript>().averageSpending = float.Parse(shops[i - 1].AverageSpending);
                newShop.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
    }

    public void CalculateMultipliers()
    {
        priceMultiplier = 1;
        customerMultiplier = 1;
        //Applying the custom settings from the UI
        //Sales is 15% off a.k.a 0.85 multiplier if it is 'Yes'

        if (settings.Sales == "Yes")
        {
            this.priceMultiplier *= 0.85f;
        }
        else
        {
            this.priceMultiplier *= 1;
        }

        switch (settings.Holiday)
        {
            case ("Christmas"):
                customerMultiplier += customerMultiplier * 1;
                priceMultiplier += priceMultiplier * 5;
                break;
            case ("Valentine's day"):
                customerMultiplier += customerMultiplier * 0.3f;
                priceMultiplier += priceMultiplier * 3;
                break;
            case ("Halloween"):
                customerMultiplier += customerMultiplier * 0.25f;
                priceMultiplier += priceMultiplier * 3;
                break;
            case ("BlackFriday"):
                customerMultiplier += customerMultiplier * 3;
                priceMultiplier += priceMultiplier * 7;
                break;
            default:

                break;
        }

        switch (settings.DayOfTheWeek)
        {
            case ("MONDAY"):

                break;
            case ("TUESDAY"):

                break;
            case ("WEDNESDAY"):

                break;
            case ("THURSDAY"):

                break;
            case ("FRIDAY"):
                customerMultiplier += customerMultiplier * 0.1f;
                priceMultiplier += priceMultiplier * 0.5f;
                break;
            case ("SATURDAY"):
                customerMultiplier += customerMultiplier * 0.3f;
                priceMultiplier += priceMultiplier;
                break;
            case ("SUNDAY"):
                customerMultiplier += customerMultiplier * 0.3f;
                priceMultiplier += priceMultiplier;
                break;
            default:

                break;
        }
        switch (settings.Weather)
        {
            case ("Sunny"):
                customerMultiplier -= customerMultiplier * 0.25f;
                priceMultiplier -= priceMultiplier * 0.20f;
                break;
            case ("Cloudy"):
                customerMultiplier += customerMultiplier * 0.17f;
                priceMultiplier += priceMultiplier * 0.1f;
                break;
            case ("Rainy"):
                customerMultiplier += customerMultiplier * 0.15f;
                priceMultiplier += priceMultiplier * 0.2f;
                break;
            case ("Snowy"):
                customerMultiplier += customerMultiplier * 0.20f;
                priceMultiplier += priceMultiplier * 0.2f;
                break;
            default:

                break;
        }
        ApplyMultipliers();
    }

    private void ApplyMultipliers()
    {
        foreach (var shop in shopInstances)
        {
            shop.GetComponent<shopScript>().SetAveragePrice(priceMultiplier);
        }
        foreach (var shop in remainingShops)
        {
            shop.GetComponent<shopScript>().SetAveragePrice(priceMultiplier);
        }
    }

    public void StartSimulation()
    {
        int customerCount = (int)System.Math.Ceiling(20 * customerMultiplier);
        customers = new GameObject[customerCount];
        for (int i = 0; i < customers.Length; i++)
        {
            customerSpawn = new Vector3(0f, 6f, 0f);
            customers[i] = Instantiate(customerPrefab, customerSpawn, Quaternion.identity);
            totalCustomers++;
            customers[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.2f, 0.9f), Random.Range(0.2f, 0.9f), Random.Range(0.2f, 0.9f));
            customers[i].GetComponent<CustomerClass>().mall = this;
        }
    }

    public void StopSimulation()
    {
        totalRevenue = 0;
        totalCustomers = 0;

        foreach (GameObject c in customers)
        {
            Destroy(c);
        }
        foreach (GameObject s in shopInstances)
        {
            s.GetComponent<shopScript>().ResetRevenue();
        }
        GameObject.Find("PowerSwitch").GetComponent<SimulationSwitch>().ExecuteSimulation();
    }

    public void Swapping()
    {
        if (swapping)
            swapping = false;
        else
            swapping = true;
    }

    private void Update()
    {
        totalCustomersLabel.text = "" + totalCustomers;
        if(started == false)
        {
            gT.StartTicking();
            started = true;
        }
    }

    public void Swap(GameObject shop)
    {
        if (shop.GetComponent<shopScript>().category != Category.EXIT)
        {
            if (swap != null)
            {
                if(swap == shop)
                {
                    swap = null;
                    return;
                }

                if (remainingShops.Contains(swap) && remainingShops.Contains(shop))
                {
                    swap = null;
                    return;
                }
                string tempLabel = "";
                string tempOptimizationName = "";
                string tempOptimizationCategory = "";
                GameObject tempShopInstance = new GameObject();


                //always makes sure swap is the shop on the screen and shop is the UI object
                if (remainingShops.Contains(swap))
                {
                    GameObject gameObject;

                    gameObject = swap;
                    swap = shop;
                    shop = gameObject;
                }

                if (remainingShops.Contains(shop))
                {
                    int index = shopInstances.ToList().IndexOf(swap);
                    int index1 = remainingShops.IndexOf(shop);

                    shopLabels[index].text = shop.GetComponent<shopScript>().shopName;


                    shop.GetComponent<shopScript>().SetPencil(pencils[index]);

                    tempShopInstance = shopInstances[index];
                    shopInstances[index] = remainingShops[index1];
                    remainingShops[index1] = tempShopInstance;

                    int posID;
                    posID = swap.GetComponent<shopScript>().positionID;
                    swap.transform.position = new Vector3(1000f, 1000f);
                    swap.GetComponent<shopScript>().positionID = shop.GetComponent<shopScript>().positionID;
                    shop.GetComponent<shopScript>().SetSpot(posID);
                    shop.GetComponent<shopScript>().positionID = posID;

                    // Setting the TMP Labels in the ShopResult tab to null, for the shop in the Shop List
                    shopScript s = remainingShops[index1].GetComponent<shopScript>();
                    remainingShops[index1].GetComponent<shopScript>().SetText(null, null, null);

                    shopScript p = shopInstances[index].GetComponent<shopScript>();
                    // Setting the TMP Labels in the ShopResult tab
                    shopInstances[index].GetComponent<shopScript>().SetText(shopInfo[index].transform.GetChild(2).GetComponent<TextMeshProUGUI>(), shopInfo[index].transform.GetChild(4).GetComponent<TextMeshProUGUI>(), shopInfo[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
                    
                    // Sets the Label text in the Optimization tab
                    shopOptimizationList[index - 1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shop.GetComponent<shopScript>().shopName;
                    shopOptimizationList[index - 1].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = shop.GetComponent<shopScript>().category.ToString();

                    sc.UpdateList();
                    swap = null;
                    Debug.Log("Swapped");
                    return;
                }

                for (int i = 0; i < shopInstances.Length; i++)
                {
                    if (shopInstances[i] == shop)
                    {

                        tempLabel = shopLabels[toSwap].text;
                        shopLabels[toSwap].text = shopLabels[i].text;
                        shopLabels[i].text = tempLabel;

                        shopInstances[toSwap].GetComponent<shopScript>().SetPencil(pencils[i]);
                        shopInstances[i].GetComponent<shopScript>().SetPencil(pencils[toSwap]);

                        tempShopInstance = shopInstances[toSwap];
                        shopInstances[toSwap] = shopInstances[i];
                        shopInstances[i] = tempShopInstance;


                        // Setting the TMP Labels in the ShopResult tab to null, for the shop in the Shop List
                        shopInstances[toSwap].GetComponent<shopScript>().SetText(shopInfo[toSwap].transform.GetChild(2).GetComponent<TextMeshProUGUI>(), shopInfo[toSwap].transform.GetChild(4).GetComponent<TextMeshProUGUI>(), shopInfo[toSwap].transform.GetChild(0).GetComponent<TextMeshProUGUI>());

                        // Setting the TMP Labels in the ShopResult tab
                        shopInstances[i].GetComponent<shopScript>().SetText(shopInfo[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>(), shopInfo[i].transform.GetChild(4).GetComponent<TextMeshProUGUI>(), shopInfo[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());

                        // Swaps the labels in the Optimization tab
                        shopOptimizationList[toSwap - 1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = shop.GetComponent<shopScript>().shopName;
                        shopOptimizationList[toSwap - 1].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = shop.GetComponent<shopScript>().category.ToString();
                        shopOptimizationList[i - 1].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = swap.GetComponent<shopScript>().shopName;
                        shopOptimizationList[i - 1].transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = swap.GetComponent<shopScript>().category.ToString();

                        int temp;

                        temp = swap.GetComponent<shopScript>().positionID;

                        swap.GetComponent<shopScript>().SetSpot(shop.GetComponent<shopScript>().positionID);

                        shop.GetComponent<shopScript>().SetSpot(temp);


                        swap = null;
                        Debug.Log("Swapped");

                        return;
                    }
                }
            }
            else
            {
                if (remainingShops.Contains(shop))
                {
                    swap = shop;
                    toSwap = remainingShops.IndexOf(shop);
                    return;
                }
                for (int i = 0; i < shopInstances.Length; i++)
                {
                    if (shopInstances[i] == shop)
                    {
                        swap = shop;
                        toSwap = i;
                        return;
                    }
                }
            }
        }
    }

    public void Exit(GameObject cust)
    {
        GameObject[] temp = new GameObject[customers.Length];
        for (int i = 0; i < customers.Length; i++)
        {
            if(customers[i] != cust)
            {       
                temp[i] = customers[i];
            }
            else
            {
                customerSpawn = new Vector3(0f, 6f, 0f);
                customers[i] = Instantiate(customerPrefab, customerSpawn, Quaternion.identity);
                customers[i].GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.2f, 0.9f), Random.Range(0.2f, 0.9f), Random.Range(0.2f, 0.9f));
                customers[i].GetComponent<CustomerClass>().mall = this;
                totalCustomers++;
                temp[i] = customers[i];
            }
        }
        customers = temp;
    }

    public GameObject RandomShop(int spot)
    {
        foreach (GameObject shop in shopInstances)
        {
            if (shop.GetComponent<shopScript>().positionID == spot)
            {
                return shop;
            }
        }
        Debug.Log("You should not be here");
        return null;
    }

    public void IncreaseRevenue(double cash)
    {
        this.totalRevenue += cash;
        totalRevenueLabel.text = "" + totalRevenue;
    }

    public void SaveShopChanges()
    {
        // Finds the first shop in the shop list which has the name input into the form and updates it's settings
        if (formName.text != "")
        {
            shopScript shopToChange = shopInstances.First(s => s.GetComponent<shopScript>().shopName == formName.text).GetComponent<shopScript>();
            shopToChange.UpdateSettings();
            shopLabels.First(l => l.GetComponent<TextMeshProUGUI>().text == formName.text).GetComponent<TextMeshProUGUI>().text = shopToChange.shopName;
        }
        else
        {
            GameObject newShop = Instantiate(shopPrefab, new Vector3(1000f, 1000f), Quaternion.identity);
            remainingShops.Add(newShop);
            newShop.GetComponent<shopScript>().AddEditWindow(editWindowContent);
            newShop.GetComponent<shopScript>().SetPosition(remainingShops.IndexOf(newShop) + 6);
            newShop.GetComponent<shopScript>().shopName = createName.text;
            Category category = (Category)System.Enum.Parse(typeof(Category), createCategory.options[createCategory.value].text);
            newShop.GetComponent<shopScript>().SetCategory(category);
            newShop.GetComponent<shopScript>().busyHours = createBusy.text;
            float avgSpending = float.Parse(createSpending.text);
            newShop.GetComponent<shopScript>().averageSpending = avgSpending;
            newShop.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            UIHandler.Instance.SaveShop(createName.text, category, avgSpending, createBusy.text);
        }
    }

    public List<GameObject> GetShops()
    {
        return remainingShops;
    }
}
