using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class shopScript : MonoBehaviour
{
    [HideInInspector]
    private ShopSpawner mall = ShopSpawner.Instance;
    public float averageSpending = 20;
    public string busyHours = "14:00";
    public Category category;
    public string shopName;
    public int positionID;
    public string oldName;
    public List<GameObject> customers;
    public double cashMoney;

    private List<GameObject> cells;
    private TextMeshProUGUI positionText, shopNameText, revenueText;
    private Image pencil;
    private TextMeshProUGUI formName;
    private TMP_Dropdown editCategory;
    private TMP_InputField editName, editAverageSpending, editBusyHours;
    private Transform editWindowContent;
    private void Awake()
    {
        cells = new List<GameObject>();
    }

    public void AddEditWindow(Transform editWindowContent)
    {
        formName = editWindowContent.GetChild(1).GetComponent<TextMeshProUGUI>();
        editCategory = editWindowContent.transform.GetChild(3).GetComponent<TMP_Dropdown>();
        editName = editWindowContent.transform.GetChild(5).GetComponent<TMP_InputField>();
        editAverageSpending = editWindowContent.transform.GetChild(7).GetComponent<TMP_InputField>();
        editBusyHours = editWindowContent.transform.GetChild(9).GetComponent<TMP_InputField>();
    }
    public void SetSpot(int spotId)
    {
        gameObject.transform.position = mall.spots[spotId].transform.position;
        gameObject.transform.localScale = mall.spots[spotId].transform.lossyScale;
        SetPosition(spotId);
    }

    public void SetPosition(int position)
    {
        this.positionID = position;
    }

    public void SetPencil(Image pencil)
    {
        pencil.GetComponent<Button>().onClick.RemoveAllListeners();
        this.pencil = pencil;
        pencil.GetComponent<Button>().onClick.AddListener(Edit);
    }

    public void SetText(TextMeshProUGUI s, TextMeshProUGUI r, TextMeshProUGUI p)
    {
        shopNameText = s;
        revenueText = r;
        positionText = p;
        if (s != null && p != null)
        {
            shopNameText.text = "" + shopName;
            positionText.text = "" + positionID;
        }
    }

    public void SetCategory(Category cat)
    {
        category = cat;
        if (category == Category.EXIT)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void SetAveragePrice(float priceMultiplier)
    {
        averageSpending *= priceMultiplier;
    }

    public Category GetCategory()
    {
        return category;
    }

    public void AddMe(GameObject cell)
    {
        cells.Add(cell);
    }

    public void Purchase(GameObject customer)
    {
        customers.Add(customer);

        if (this.category == Category.EXIT)
        {
            customer.GetComponent<customerBrain>().wantsToMove = false;
            customer.GetComponent<customerBrain>().favShop = null;
            customer.GetComponent<CustomerClass>().mall.Exit(customer);
            Destroy(customer);
        }
        else
        {
            double increase = System.Math.Round(UnityEngine.Random.Range(averageSpending - 5, averageSpending + 5), 2);
            cashMoney += increase;
            mall.IncreaseRevenue(increase);
        }
    }

    public GameObject RandomTarget()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject cell = cells[UnityEngine.Random.Range(0, cells.Count)];
            if(cell.GetComponent<cellLogic>().isWalkable)
            {
                return cell;
            }
        }
         return null;
    }

    public void ResetRevenue()
    {
        cashMoney = 0;
    }

    public void Edit()
    {
        formName.text = shopName;
        editCategory.value = editCategory.options.FindIndex(option => option.text.ToLower() == category.ToString().ToLower());
        editName.text = shopName;
        editAverageSpending.text = averageSpending.ToString();
        editBusyHours.text = busyHours;
    }

    public void UpdateSettings()
    {
        oldName = formName.text;
        shopName = editName.text;
        category = (Category)System.Enum.Parse(typeof(Category), editCategory.options[editCategory.value].text);
        averageSpending = float.Parse(editAverageSpending.text);
        busyHours = editBusyHours.text;

        UIHandler.Instance.UpdateShop(oldName, shopName, category, averageSpending, busyHours);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mall.swapping)
            {
                mall.Swap(gameObject);
                Debug.Log("added for swap");
            }
        }
    }

    public void SwapClick()
    {
        if (mall.swapping)
        {
            mall.Swap(gameObject);
            Debug.Log("added for swap");
        }
    }

    private void Update()
    {
       if(category != Category.EXIT)
        {
            try
            {
                revenueText.text = "" + cashMoney;
            }
            catch (Exception e) { }
        }
    }
}
