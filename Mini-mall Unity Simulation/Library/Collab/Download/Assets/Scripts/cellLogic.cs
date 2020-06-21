using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellLogic : MonoBehaviour
{
    public GameObject wall;
    public GameObject shop;
    public GameObject customer;
    public int gCost;
    public int fCost;
    public int hCost;
    public bool isWalkable = true;
    private int customersOnCell = 0;

    public GameObject cameFrom;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == wall.layer)
        {
            gameObject.SetActive(false);
        }
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == wall.layer)
        {
            isWalkable = false;
        }

        if(collision.gameObject.layer == shop.layer && isWalkable == true)
        {
            collision.GetComponent<shopScript>().AddMe(gameObject);
        }

        if (collision.gameObject.layer == customer.layer)
        {
            isWalkable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.layer == customer.layer)
            {
                isWalkable = true;
            }
    }
}
