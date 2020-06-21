using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [HideInInspector]
    public ShopSpawner mall = ShopSpawner.Instance;
    public TMP_Dropdown load;
    public TMP_InputField saveName;
    public TMP_InputField startTime;
    public TMP_InputField endTime;
    public TMP_Dropdown holiday;
    public TMP_Dropdown sale;
    public TMP_Dropdown dayOfTheWeek;
    public TMP_Dropdown weather;
    Settings settings;
    List<shopResult> results;

    string server = "http://i402538.hera.fhict.nl/";

    /// <summary>
    /// UIHangler's Singleton instance
    /// </summary>
    /// <returns></returns>
    public static UIHandler Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Transforms a json list with objects, into an array of objects of type <T>
    /// </summary>
    public class JsonHelper
    {
        public static T[] getJsonArray<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetSettings());
        StartCoroutine(GetShops());
    }

    /// <summary>
    /// Save a preset with the settings in the Settings Tab, and the name from the Preset Name textbox
    /// </summary>
    public void SavePreset()
    {
        if(saveName.text == "" || startTime.text == "" || endTime.text == "" || 
            weather.options[weather.value].text == "Please Select" || holiday.options[holiday.value].text == "Please Select" || 
            dayOfTheWeek.options[dayOfTheWeek.value].text == "Please Select" || sale.options[sale.value].text == "Please Select")
        {
            Debug.Log("Please fill in all fields!");
            return;
        }
        try
        {
            DateTime StartTime = DateTime.ParseExact(startTime.text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime EndTime = DateTime.ParseExact(endTime.text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch(FormatException)
        {
            Debug.Log("Please enter the hours, using a correct time format!");
            return;
        }

        StartCoroutine(PostSettings());
        load.ClearOptions();
    }

    /// <summary>
    /// Selects a preset, from the list of presets in the shopSpawner class, and sets the shop positions to match it's saved ones
    /// </summary>
    public void SelectPreset()
    {
        Settings preset = mall.presets.Find(p => p.Name == load.captionText.text);
        ShopSpawner.Instance.settings.StartTime = preset.StartTime;
        startTime.text = preset.StartTime;
        ShopSpawner.Instance.settings.EndTime = preset.EndTime;
        endTime.text = preset.EndTime;
        ShopSpawner.Instance.settings.Holiday = preset.Holiday;
        holiday.value = holiday.options.FindIndex(option => option.text.ToLower() == preset.Holiday.ToLower());
        ShopSpawner.Instance.settings.DayOfTheWeek = preset.DayOfTheWeek;
        dayOfTheWeek.value = dayOfTheWeek.options.FindIndex(option => option.text.ToLower() == preset.DayOfTheWeek.ToLower());
        ShopSpawner.Instance.settings.Weather = preset.Weather;
        weather.value = weather.options.FindIndex(option => option.text.ToLower() == preset.Weather.ToLower());
        ShopSpawner.Instance.settings.Sales = preset.Sales;
        sale.value = sale.options.FindIndex(option => option.text.ToLower() == preset.Sales.ToLower());
        ShopSpawner.Instance.CalculateMultipliers();
        foreach (ShopPlacement shop in preset.Shops)
        {
            mall.swapping = true;
            GameObject first = null;
            GameObject second = null;
            try
            {
                first = mall.shopInstances.First(s => s.GetComponent<shopScript>().positionID == shop.PositionID);
            } catch { }
            if (first == null)
            {
                first = mall.remainingShops.First(s => s.GetComponent<shopScript>().positionID == shop.PositionID);
            }
            try
            {
                second = mall.shopInstances.First(s => s.GetComponent<shopScript>().shopName == shop.ShopName);
            } catch { }
            if (second == null)
            {
                second = mall.remainingShops.First(s => s.GetComponent<shopScript>().shopName == shop.ShopName);
            }
            mall.Swap(first);
            mall.Swap(second);
            mall.swapping = false;
        }
        saveName.text = preset.Name;
    }

    /// <summary>
    /// Saves the results for a completed simulation
    /// </summary>
    /// <param name="endTime"> End time for the simulation, at the time the StopSimulation is called)</param>
    public void SaveResults(string endTime)
    {
        StartCoroutine(PostResults(endTime));
    }

    /// <summary>
    /// Saves a single shop into the database, whenever new shops are created
    /// </summary>
    /// <param name="shopName"> Name of the shop </param>
    /// <param name="category"> Category of the shop </param>
    /// <param name="averageSpending"> Average customer spending in the shop </param>
    /// <param name="busyHours"> Busy hours of the shop </param>
    public void SaveShop(string shopName, Category category, float averageSpending, string busyHours)
    {
        StartCoroutine(PostShop(shopName, category, averageSpending, busyHours));
    }

    /// <summary>
    /// Updates a shop into the database
    /// </summary>
    /// <param name="oldName"> Old name of the shop </param>
    /// <param name="shopName"> New name for the shop </param>
    /// <param name="category"> Category of the shop </param>
    /// <param name="averageSpending"> Average customer spending in the shop </param>
    /// <param name="busyHours"> Busy hours of the shop</param>
    public void UpdateShop(string oldName, string shopName, Category category, float averageSpending, string busyHours)
    {
        StartCoroutine(PatchShop(oldName, shopName, category, averageSpending, busyHours));
    }

    /// <summary>
    /// Loads all results, matching the current Settings in the "Settings Tab"
    /// </summary>
    public void LoadResults()
    {
        settings = new Settings(saveName.text, startTime.text, endTime.text, weather.options[weather.value].text, 
            holiday.options[holiday.value].text, dayOfTheWeek.options[dayOfTheWeek.value].text, sale.options[sale.value].text);
        results = new List<shopResult>();
        StartCoroutine(GetResults(settings));
    }

    /// <summary>
    /// Loads ALL shops from the database
    /// </summary>
    public void LoadShops()
    {
        StartCoroutine(GetShops());
    }

    /// <summary>
    /// Posts a single shop into the databse, with the given parameters
    /// </summary>
    /// <param name="shopName"></param>
    /// <param name="category"></param>
    /// <param name="averageSpending"></param>
    /// <param name="busyHours"></param>
    /// <returns></returns>
    private IEnumerator PostShop(string shopName, Category category, float averageSpending, string busyHours)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", shopName);
        string test = category.ToString();
        form.AddField("Category", test);
        string test2 = averageSpending.ToString();
        form.AddField("AverageSpending", test2);
        form.AddField("BusyHours", busyHours);

        UnityWebRequest listData = UnityWebRequest.Post(server + "add_shop.php", form);

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log("There was an error saving this shop, please try again later");
            Debug.Log(listData.error);
        }
        else
        {
            Debug.Log("The shop has been successfully saved!");
        }
    }

    /// <summary>
    /// Updates a single shop into the database, with the given parameters
    /// </summary>
    /// <param name="oldName"></param>
    /// <param name="shopName"></param>
    /// <param name="category"></param>
    /// <param name="averageSpending"></param>
    /// <param name="busyHours"></param>
    /// <returns></returns>
    private IEnumerator PatchShop(string oldName, string shopName, Category category, float averageSpending, string busyHours)
    {
        WWWForm form = new WWWForm();
        form.AddField("OldName", oldName);
        form.AddField("Name", shopName);
        form.AddField("AverageSpending", averageSpending.ToString());
        form.AddField("BusyHours", busyHours);
        form.AddField("Category", category.ToString());

        UnityWebRequest listData = UnityWebRequest.Post(server + "update_shop.php", form);

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log("There was an error saving this shop, please try again later");
            Debug.Log(listData.error);
        }
        else
        {
            Debug.Log("The shop has been successfully saved!");
        }
    }

    /// <summary>
    /// Gets all shops from the database
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetShops()
    {

        UnityWebRequest listData = UnityWebRequest.Get(server + "get_shops.php");
        Debug.Log(server + "get_shops.php");

        listData.downloadHandler = new DownloadHandlerBuffer();

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log(listData.error);
        }
        else
        {
            Debug.Log("The shops have been loaded");
            mall.shops = JsonHelper.getJsonArray<Shop>(listData.downloadHandler.text).ToList();
        }
        mall.InstantiateShops();
    }

    /// <summary>
    /// Posts the a new preset with settings from the "Settings" tab and a name from the "Preset Name" textbox in the "Presets" tab
    /// </summary>
    /// <returns></returns>
    private IEnumerator PostSettings()
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", saveName.text);
        form.AddField("StartTime", startTime.text);
        form.AddField("EndTime", endTime.text);
        form.AddField("Weather", weather.options[weather.value].text);
        form.AddField("Holiday", holiday.options[holiday.value].text);
        form.AddField("Sales", sale.options[sale.value].text);
        form.AddField("DayOfTheWeek", dayOfTheWeek.options[dayOfTheWeek.value].text);


        UnityWebRequest listData = UnityWebRequest.Post(server + "add_simulation.php", form);

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log("There was an error saving these settings, please try again later");
            Debug.Log(listData.error);
        }
        else
        {
            Debug.Log("The settings have been successfully saved!");
            Debug.Log("Upload complete!");
        }
        StartCoroutine(PostShopPositions());
    }

    /// <summary>
    /// Posts the shop positions for each shop, related to the previously saved Preset
    /// </summary>
    /// <returns></returns>
    private IEnumerator PostShopPositions()
    {
        foreach (GameObject shop in mall.shopInstances)
        {
            string simulationName = saveName.text;
            shopScript shopItem = shop.GetComponent<shopScript>();
            if (shopItem.shopName != "Exit")
            {
                string shopName = shopItem.shopName;
                int positionID = shopItem.positionID;
                WWWForm form = new WWWForm();
                form.AddField("SimulationName", simulationName);
                form.AddField("ShopName", shopName);
                form.AddField("PositionID", positionID);

                UnityWebRequest listData = UnityWebRequest.Post(server + "add_shop_position.php", form);
                yield return listData.SendWebRequest();

                if (listData.isNetworkError || listData.isHttpError)
                {
                    Debug.Log("There was an error saving the positioning, please try again later");
                    Debug.Log(listData.error + "    simulation name:" + simulationName + "  shopName:" + shopName + "  position:" + positionID);
                }
                else
                {
                    Debug.Log("The position " + positionID + " has been successfully saved!");
                    Debug.Log("Upload complete!");
                }
            }
        }
        StartCoroutine(GetSettings());
    }

    /// <summary>
    /// Gets all presets from the database
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetSettings()
    {
        mall.presets.Clear();
        UnityWebRequest listData = UnityWebRequest.Get(server + "get_simulation.php");
        Debug.Log(server + "get_simulation.php");

        listData.downloadHandler = new DownloadHandlerBuffer();

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log(listData.error);
        }
        else
        {
            Debug.Log("The settings have been loaded");
            mall.presets = JsonHelper.getJsonArray<Settings>(listData.downloadHandler.text).ToList();
            foreach (Settings p in mall.presets)
            {
                p.GetDuration();
            }
        }

        foreach (Settings preset in mall.presets)
        {
            WWWForm form = new WWWForm();
            form.AddField("SimulationName", preset.Name);

            UnityWebRequest shopData = UnityWebRequest.Post(server + "get_shop_position_where_simulation_name.php", form);

            shopData.downloadHandler = new DownloadHandlerBuffer();

            yield return shopData.SendWebRequest();

            if (shopData.isNetworkError || shopData.isHttpError || shopData.downloadHandler.text == "No rows")
            {
                Debug.Log(shopData.error);
                Debug.Log("Form data: " + form.data);
            }
            else
            {
                Debug.Log("The shops have been loaded");
                preset.Shops = JsonHelper.getJsonArray<ShopPlacement>(shopData.downloadHandler.text).ToList<ShopPlacement>();
            }
        }
        ShowPresets();
    }

    /// <summary>
    /// Gets all results from the database with the provided settings
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    private IEnumerator GetResults(Settings settings)
    {
        WWWForm form = new WWWForm();
        form.AddField("Weather", settings.Weather);
        form.AddField("Holiday", settings.Holiday);
        form.AddField("DayOfTheWeek", settings.DayOfTheWeek);
        form.AddField("Sales", settings.Sales);

        UnityWebRequest listData = UnityWebRequest.Post(server + "get_positions_for_optimization.php", form);
        Debug.Log(server + "get_positions_for_optimization.php");

        listData.downloadHandler = new DownloadHandlerBuffer();

        yield return listData.SendWebRequest();

        if (listData.isNetworkError || listData.isHttpError)
        {
            Debug.Log(listData.error);
        }
        else
        {
            results = JsonHelper.getJsonArray<shopResult>(listData.downloadHandler.text).ToList();
            GameObject.Find("ShopOptimizer").GetComponent<ShopOptimization>().OptimizeShopPlacement(results);
        }
    }

    /// <summary>
    /// Posts a result into the database, for the latest simulation that was run
    /// </summary>
    /// <param name="endTime"></param>
    /// <returns></returns>
    private IEnumerator PostResults(string endTime)
    {
        WWWForm form = new WWWForm();
        Debug.Log("Customers: " + mall.totalCustomersLabel.text + "    Revenue: " + mall.totalRevenueLabel.text);
        form.AddField("SimulationName", saveName.text);
        form.AddField("TotalIncome", mall.totalRevenueLabel.text);
        form.AddField("TotalVisitors", mall.totalCustomersLabel.text);
        //Finds the preset with the given name, inside of the saveName textbox, and gets its duration  
        //*based on the endtime, taken from the timer at the moment the Stop Simulation button is pressed*
        string duration = mall.presets.Find(p => p.Name == saveName.text).GetDuration(endTime);

        if(duration == null)
        {
            Debug.Log("Please enter the correct time format!");
            yield break;
        }
        form.AddField("Duration", duration);


        UnityWebRequest data = UnityWebRequest.Post(server + "add_result.php", form);

        yield return data.SendWebRequest();
        int resultID = -1;
        if (data.isNetworkError || data.isHttpError)
        {
            Debug.Log("There was an error saving this result, please try again later");
            Debug.Log(data.error);
        }
        else
        {
            resultID = Convert.ToInt32(data.downloadHandler.text);
            Debug.Log("Upload complete!");
            StartCoroutine(PostShopsResult(resultID));
        }

    }

    /// <summary>
    /// Posts the shop results into the database, for the latest simulation that was run
    /// </summary>
    /// <param name="resultID"></param>
    /// <returns></returns>
    private IEnumerator PostShopsResult(int resultID)
    {
        if (resultID != -1)
        {
            foreach (GameObject shop in mall.shopInstances)
            {
                shopScript shopItem = shop.GetComponent<shopScript>();
                if (shopItem.shopName != "Exit")
                {
                    WWWForm form = new WWWForm();
                    form.AddField("ResultID", resultID);
                    form.AddField("ShopName", shopItem.shopName);
                    form.AddField("Income", shopItem.cashMoney.ToString());
                    form.AddField("Visitors", shopItem.customers.Count);


                    UnityWebRequest www = UnityWebRequest.Post(server + "add_shop_result.php", form);

                    yield return www.SendWebRequest();

                    if (www.isNetworkError || www.isHttpError)
                    {
                        Debug.Log("There was an error saving this result, please try again later");
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log("Upload complete!");
                    }
                }
            }
        }
        GameObject.Find("PowerSwitch").GetComponent<SimulationSwitch>().KillSimulation();
    }

    /// <summary>
    /// Shows the loaded presets into the "Load a preset" dropdown
    /// </summary>
    public void ShowPresets()
    {
        List<string> presetNames = new List<string>();
        foreach (Settings preset in mall.presets)
        {
            string name = preset.Name.Split('-')[0];
            if(!presetNames.Contains(name))
            presetNames.Add(name);
        }
        load.AddOptions(presetNames);
    }

}
