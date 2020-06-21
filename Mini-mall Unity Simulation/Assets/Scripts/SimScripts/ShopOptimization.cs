using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopOptimization : MonoBehaviour
{
    [HideInInspector]
    public List<shopResult> shopResults; //this is the results
    [HideInInspector]
    public bool simWorking;
    [HideInInspector]
    public ShopSpawner mall = ShopSpawner.Instance;
    private Dictionary<int, string> shopPositions; //Position, shopName
    public GameObject confirmation;
    public SimulationSwitch sim;
    public GameObject timeSpeed;
    public TMP_InputField saveName;
    public void GetResults()
    {
        shopPositions = new Dictionary<int, string>();
        UIHandler.Instance.LoadResults();
    }

    public void OptimizeShopPlacement(List<shopResult> results)
    {
        shopResults = results;
        //get the array of json objects, it is sorted by positionID
        //there is a new GET for this array

        double[] shopRevenues = new double[5];      //This shopRevenue array represents the highest income for every POSITION. They are always 5.
        List<string> shopNames = new List<string>(5);    //shopName array saves the name of the most profitable shop for each POSITION. 
        if (shopResults.Count >= 15)      //At least 15, because the research showed that we need at least 3 simulation for our algorithm to run properly and deliver.
        {
            int j = 0;
            foreach (shopResult result in shopResults)
            {
                
                if (shopRevenues[j] < result.Income && !shopNames.Contains(result.ShopName) && !shopPositions.ContainsKey(result.PositionID))
                {
                    shopRevenues[j] = result.Income;
                    shopNames.Add(result.ShopName);
                    shopPositions.Add(result.PositionID, result.ShopName);
                    j++;
                }
                if(j==5)
                {
                    break;
                }
                
            }
        }
        else
        {
            confirmation.SetActive(true);
        }
        foreach (KeyValuePair<int,string> shop in shopPositions)
        {
            mall.swapping = true;
            mall.Swap(mall.shopInstances.First(s => s.GetComponent<shopScript>().positionID == shop.Key));
            mall.Swap(mall.shopInstances.First(s => s.GetComponent<shopScript>().shopName == shop.Value));
            mall.swapping = false;
        }
    }

    public void RollerCoasterStart()
    {
        StartCoroutine(RollerCoaster());
    }
    IEnumerator RollerCoaster()
    {
        Dictionary<int, string> array1 = new Dictionary<int, string>
        {
            { 1, mall.shopInstances[1].GetComponent<shopScript>().shopName },
            { 2, mall.shopInstances[2].GetComponent<shopScript>().shopName },
            { 3, mall.shopInstances[3].GetComponent<shopScript>().shopName },
            { 4, mall.shopInstances[4].GetComponent<shopScript>().shopName },
            { 5, mall.shopInstances[5].GetComponent<shopScript>().shopName }
        }; //original array, takes positions and shops from ui; never changes throughout the code below!

        Dictionary<int, string> array2 = new Dictionary<int, string>(); //iterative array, empty in the begnning; changes each loop, using the positions of array1
        sim.StartSimulation();
        timeSpeed.transform.GetChild(0).GetChild(1).GetComponent<TimeSpeed>().Speed3();
        simWorking = true;

        //run sim once with array1 because we also want to use the current positioning for the calculations. this avoids going through the loop below once
            for (int i = 0; i <= 3; i++)   //loops 4 times. uses array1 as a map and array2 for switching the placements. 
            {
                yield return new WaitUntil(() => simWorking == false);

                array2[i + 1] = array1[5]; //always begin with copying the last shop from array1 into the first position of array2

                int pivot1 = 1;  //pointer for array1; always points to the shop we are copying from array1
                int pivot2 = i + 2;  //pointer for array2; always points to the position we are BEGINNING with

                for (int j = pivot2; j <= 5; j++) //from pivot2 till the end of the array
                {
                    array2[j] = array1[pivot1];
                    pivot1++;
                }
                if (pivot2 > 2)
                { //avoids array out of bounds exeption and starts copying shops to the beginning of array2
                    for (int a = 1; a <= pivot2 - 2; a++) //from the beginning of array2 till pivot2, but also skipping the first switching of places
                    {
                        array2[a] = array1[pivot1];
                        pivot1++;
                    }
                }
            foreach (KeyValuePair<int, string> shop in array2)
            {
                mall.swapping = true;
                mall.Swap(mall.shopInstances.First(s => s.GetComponent<shopScript>().positionID == shop.Key));
                mall.Swap(mall.shopInstances.First(s => s.GetComponent<shopScript>().shopName == shop.Value));
                mall.swapping = false;
            }
            saveName.text = saveName.text.Split('-')[0] + "- " + DateTime.Now;      
            int temp = mall.presets.Count();
            UIHandler.Instance.SavePreset();
            yield return new WaitUntil(() => temp < mall.presets.Count);
            timeSpeed.transform.GetChild(0).GetChild(1).GetComponent<TimeSpeed>().Speed3();
            sim.StartSimulation();
                simWorking = true;
            }
        GetResults();
    }
}

[Serializable]
public class shopResult
{
    public int ResultID;
    public int PositionID;
    public string ShopName;
    public double Income;
    public shopResult(int ResultID, int PositionID, string ShopName, double Income)
        {
        this.ResultID = ResultID;
        this.PositionID = PositionID;
        this.ShopName = ShopName;
        this.Income = Income;
        }
    }
