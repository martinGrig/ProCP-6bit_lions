using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour
{
    private List<GameObject> cells;
    public int nameS;
    private Category category;

    private void Awake()
    {
        cells = new List<GameObject>();
    }
    private void Start()
    {
        
        nameS = Random.Range(0, 100);
    }

    public void AddMe(GameObject cell)
    {
        cells.Add(cell);
    }
    public void SetCategory(Category cat)
    {
        category = cat;
    }
    public Category GetCategory()
    {
        return category;
    }

    public GameObject RandomTarget()
    {
        foreach (GameObject cell in cells)
        {
            if(cell.GetComponent<cellLogic>().isWalkable)
            {
                return cell;
            }
        }
         return null;
    }
}
