using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridTester : MonoBehaviour
{
    [HideInInspector]
    public ShopSpawner mall = ShopSpawner.Instance;
    public Grid grid;
    public cellLogic cell;
    private List<GameObject> openList;
    private List<GameObject> closedList;
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;
    private int gridWidth;
    private int gridHeight;
    private GameObject cellObject = null;
    private int testX = 6;
    private int testY = 10;
    private int cX;
    private int cY;
    private Vector3[] paths;
    private GameObject shop;
    private IEnumerator tick;

    // Start is called before the first frame update
    void Start()
    {
        tick = Tick();
        gridWidth = 19;
        gridHeight = 11;
        grid.CreateGrid(gridWidth, gridHeight, 1f);
    }

    public void StartTicking()
    {
        StartCoroutine(tick);
    }

    public List<GameObject> FindPath(int startX, int startY, int endX, int endY)
    {
        GameObject start = grid.GetCell(startX, startY);
        GameObject end = grid.GetCell(endX, endY);
        openList = new List<GameObject> { start };
        closedList = new List<GameObject> { };

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                cellObject = grid.GetCell(x, y);
                cellObject.GetComponent<cellLogic>().gCost = int.MaxValue;
                cellObject.GetComponent<cellLogic>().CalculateFCost();
                cellObject.GetComponent<cellLogic>().cameFrom = null;
            }
        }

        start.GetComponent<cellLogic>().gCost = 0;
        start.GetComponent<cellLogic>().hCost = Convert.ToInt32(CalculateDistanceCost(start, end));
        start.GetComponent<cellLogic>().CalculateFCost();

        while (openList.Count > 0)
        {
            GameObject current = GetLowestFCostCell(openList);
            if (current == end)
            {
                //reached end
                return CalculatePath(end);
            }

            openList.Remove(current);
            closedList.Add(current);

            foreach (GameObject neighbourCell in GetNeighbourList(current))
            {
                if (closedList.Contains(neighbourCell)) continue;
                if (!neighbourCell.GetComponent<cellLogic>().isWalkable)
                {
                    closedList.Add(neighbourCell);
                    continue;
                }

                int tentativeGCost = Convert.ToInt32(current.GetComponent<cellLogic>().gCost + CalculateDistanceCost(current, neighbourCell));
                if (tentativeGCost < neighbourCell.GetComponent<cellLogic>().gCost)
                {
                    neighbourCell.GetComponent<cellLogic>().cameFrom = current;
                    neighbourCell.GetComponent<cellLogic>().gCost = tentativeGCost;
                    neighbourCell.GetComponent<cellLogic>().hCost = Convert.ToInt32(CalculateDistanceCost(neighbourCell, end));
                    neighbourCell.GetComponent<cellLogic>().CalculateFCost();

                    if (!openList.Contains(neighbourCell))
                    {
                        openList.Add(neighbourCell);
                    }
                }
            }
        }
        //out of cells
        return null;
    }

    private List<GameObject> GetNeighbourList(GameObject currentCell)
    {
        int x = Convert.ToInt32(currentCell.transform.position.x);
        int y = Convert.ToInt32(currentCell.transform.position.y);
        List<GameObject> neighbourList = new List<GameObject>();

        if (x - 1 >= 0)
        {
            neighbourList.Add(GetCell(x - 1, y));
            if (y - 1 >= 0) neighbourList.Add(GetCell(x - 1, y - 1));
            if (y + 1 < gridHeight) neighbourList.Add(GetCell(x - 1, y + 1));
        }
        if (x + 1 < gridWidth)
        {
            neighbourList.Add(GetCell(x + 1, y));
            if (y - 1 >= 0) neighbourList.Add(GetCell(x + 1, y - 1));
            if (y + 1 < gridHeight) neighbourList.Add(GetCell(x + 1, y + 1));
        }
        if (y - 1 >= 0) neighbourList.Add(GetCell(x, y - 1));
        if (y + 1 < gridHeight) neighbourList.Add(GetCell(x, y + 1));

        return neighbourList;
    }

    private GameObject GetCell(int x, int y)
    {
        return grid.GetCell(x, y);
    }

    private List<GameObject> CalculatePath(GameObject end)
    {
        List<GameObject> path = new List<GameObject>();
        path.Add(end);
        GameObject current = end;
        while (current.GetComponent<cellLogic>().cameFrom != null)
        {
            path.Add(current.GetComponent<cellLogic>().cameFrom);
            current = current.GetComponent<cellLogic>().cameFrom;
        }
        path.Reverse();
        return path;
    }

    private float CalculateDistanceCost(GameObject a, GameObject b)
    {
        float xDistance = Mathf.Abs(a.transform.position.x - b.transform.position.x);
        float yDistance = Mathf.Abs(a.transform.position.y - b.transform.position.y);
        float remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private GameObject GetLowestFCostCell(List<GameObject> cellList)
    {
        GameObject lowestFCostCell = cellList[0];
        for (int i = 1; i < cellList.Count; i++)
        {
            if (cellList[i].GetComponent<cellLogic>().fCost < lowestFCostCell.GetComponent<cellLogic>().fCost)
            {
                lowestFCostCell = cellList[i];
            }
        }
        return lowestFCostCell;
    }
    private IEnumerator Tick()
    {
        while (true)
        {
            foreach (GameObject customer in mall.customers)
            {
                if(customer == null)
                {
                    break;
                }
                if (customer.GetComponent<customerBrain>().wantsToMove)
                {
                    Vector3 t = customer.GetComponent<customerBrain>().GetPosition();
                    cX = Convert.ToInt32(t.x);
                    cY = Convert.ToInt32(t.y);
                    shop = customer.GetComponent<customerBrain>().favShop;
                    if (shop == null)
                    {
                        shop = mall.RandomShop(customer.GetComponent<CustomerClass>().GetShop());
                        customer.GetComponent<customerBrain>().favShop = shop;
                    }

                    GameObject targetCell = shop.GetComponent<shopScript>().RandomTarget();
                    if(targetCell == null)
                    {
                        break;
                    }
                    testX = Convert.ToInt32(targetCell.transform.position.x);
                    testY = Convert.ToInt32(targetCell.transform.position.y);

                    List<GameObject> path = FindPath(cX, cY, testX, testY);
                    if (path != null && path.Count > 0)
                    {
                        paths = new Vector3[path.Count];
                        for (int i = 0; i < path.Count; i++)
                        {
                            paths[i] = path[i].transform.position;
                        }
                        if (paths.Length > 1)
                        {
                            customer.GetComponent<customerBrain>().SetPath(paths);
                        }
                    }
                }
            }
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }
    }
}
