using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int width;
    private int height;
    private int[,] gridArray;
    public GameObject test;
    private Vector2 coord;
    private List<GameObject> cells = new List<GameObject>();
    private float cellSize;
    private int counter = 0;
    public void CreateGrid(int width, int height, float cellSize)
    {
        this.cellSize = cellSize;
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        for(int x=0; x<gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                counter += 1;
                coord = new Vector2(x, y);
                cells.Add(Instantiate(test, GetWorldPosition(x,y), Quaternion.identity));
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public GameObject GetCell(int x, int y)
    {
        Vector3 location = new Vector3(x, y, 0);
        foreach (GameObject cell in cells)
        {
            if(cell.transform.position == location)
            {
                return cell;
            }
        }
        return null;
    }
}
