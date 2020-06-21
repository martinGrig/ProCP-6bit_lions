using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SimulationSwitch : MonoBehaviour
{
    [HideInInspector]
    public ShopSpawner mall = ShopSpawner.Instance;
    public TMPro.TextMeshProUGUI totalRevenue;
    public TMPro.TextMeshProUGUI totalCustomers;
    public TMPro.TMP_InputField SimulationName;
    public GameObject shopsResultList;
    public GameObject timer;
    public GameObject timeSpeed;
    public GameObject pencils;
    public ShopOptimization sim;
    public void StartSimulation()
    {
        Settings preset = mall.presets.Find(p => p.Name == SimulationName.text);
        if (SimulationName.text == "" || preset == null)
        {
            Debug.Log("Please choose a name for your Simulation and save the settings!");
            return;
        }
        //Prepare the settings for the incoming simulation
        mall.settings.Assign();
        //Finds the Results Panel tab and change to it
        GameObject results = GameObject.Find("Results Panel");
        results.transform.SetAsLastSibling();
        //Find the Tab Buttons game object, in order to change the color of the selected tab's button
        GameObject tabs = GameObject.Find("Tab Buttons");
        tabs.GetComponent<TabChanger>().ButtonPainter(GameObject.Find("Results Tab Button"));
        //Shows the Shops Result objects in the Results Tab
        for (int i = 0; i < shopsResultList.transform.childCount; i++)
        {
            shopsResultList.transform.GetChild(i).gameObject.SetActive(true);
        }
        //Starts spawning the customers
        mall.StartSimulation();
        //Show the timer and timespeed
        timeSpeed.SetActive(true);
        //Hides the pencils
        pencils.SetActive(false);
    }


    public void StopSimulation()
    {
        timeSpeed.transform.GetChild(0).GetChild(1).GetComponent<TimeSpeed>().Play();
        //Finds the Settings Panel tab and change to it
        GameObject settings = GameObject.Find("Settings Panel");
        settings.transform.SetAsLastSibling();
        //Find the Tab Buttons game object, in order to change the color of the selected tab's button
        GameObject tabs = GameObject.Find("Tab Buttons");
        tabs.GetComponent<TabChanger>().ButtonPainter(GameObject.Find("Settings Tab Button"));
        //Gets the time at the end of the simulation
        string time = timer.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text + ":" + timer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        //Calls the UIHandler to save results, after the results were save, the UIHandler will call KillSimulation()
        UIHandler.Instance.SaveResults(time);
       
    }

    //Called by the PostShopResults, which is the last coroutine in the chain, which is called whenever a simulation is ending
    public void KillSimulation()
    {
        mall.StopSimulation();
    }

    public void ExecuteSimulation()
    {
        //Set the texts to empty and disable some of the UI
        for (int i = 0; i < shopsResultList.transform.childCount; i++)
        {
            //get the shop result game object
            GameObject child = shopsResultList.transform.GetChild(i).gameObject;
            //catch the TMP text label for the revenue and clear it
            child.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = "";
            child.SetActive(false);
        }
        totalRevenue.text = "";
        totalCustomers.text = "";
        //Hides the timer and timespeed
        timer.GetComponent<Timer>().Restart();
        timeSpeed.SetActive(false);

        //Shows the pencils
        pencils.SetActive(true); 
        //optimization
        sim.simWorking = false;
    }
}
