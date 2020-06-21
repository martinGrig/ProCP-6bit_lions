using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopScript : MonoBehaviour
{
    private List<GameObject> cells;
    public Category category;
    public List<GameObject> customers;
    public double cashMoney;
    public string shopName;
    public int positionID;
    private TMPro.TextMeshProUGUI positionText;
    private TMPro.TextMeshProUGUI shopNameText;
    private TMPro.TextMeshProUGUI revenueText;
    public shopSpawner mall;

    private void Awake()
    {
        cells = new List<GameObject>();
    }
    private void Start()
    {
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mall.Swap(gameObject);
            Debug.Log("added for swap");
        }
    }

    public void AddMe(GameObject cell)
    {
        cells.Add(cell);
    }

    public void SetCategory(Category cat)
    {
        category = cat;
        if (category == Category.EXIT)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public Category GetCategory()
    {
        return category;
    }

    public void Shop(GameObject customer)
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
            cashMoney += 19;
            mall.IncreaseRevenue(19);
        }
    }

    public void SetText(TMPro.TextMeshProUGUI s, TMPro.TextMeshProUGUI r)
    {
        shopNameText = s;
        revenueText = r;
    }

    private void Update()
    {
        shopNameText.text = "" + shopName;
        revenueText.text = "" + cashMoney;
    }

    public GameObject RandomTarget()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject cell = cells[Random.Range(0, cells.Count)];
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
}
