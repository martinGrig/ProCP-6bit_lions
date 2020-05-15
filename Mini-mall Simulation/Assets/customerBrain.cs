using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerBrain : MonoBehaviour
{
    private float speed = 4f;
    private int currentPathIndex;
    private Vector3[] pathVectorList;
    public GameObject favShop = null;
    public bool wantsToMove = true;
    private float waitTime;

    private void Awake()
    {
        waitTime = 10f;
        wantsToMove = true;
    }
    private void Update()
    {
        if(waitTime <= 0)
        {
            wantsToMove = true;
            waitTime = 10f;
        }
        waitTime -= Time.deltaTime;
        if (pathVectorList != null)
        {
            StartMoving();
        }
    }
    private void StartMoving()
    {

        if (currentPathIndex <= pathVectorList.Length - 1)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pathVectorList[currentPathIndex+1], speed * Time.deltaTime);
        }

        if (gameObject.transform.position == pathVectorList[currentPathIndex + 1])
        {
            currentPathIndex++;
        }

        if (currentPathIndex >= pathVectorList.Length - 1)
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        currentPathIndex = -1;
        pathVectorList = null;
        favShop = null;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void SetPath(Vector3[] list)
    {
        wantsToMove = false;
        currentPathIndex = -1;
        pathVectorList = list;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (favShop != null)
        {
            if (collision.gameObject.layer == gameObject.layer)
            {
                wantsToMove = true;
            }
        }
    }
}
