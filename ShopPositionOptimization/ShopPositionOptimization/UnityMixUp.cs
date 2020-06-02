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
    public shopSpawner mall;
    public TMP_Dropdown load;
    public TMP_InputField saveName;
    public TMP_InputField startTime;
    public TMP_InputField endTime;
    public TMP_Dropdown holiday;
    public TMP_Dropdown sale;
    public TMP_Dropdown dayOfTheWeek;
    public TMP_Dropdown weather;
    public SimulationSwitch powerOff;

    string server = "http://i402538.hera.fhict.nl/";


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
        //UpdateSettings();
        StartCoroutine(GetSettings());
    }

    public void SavePreset()
    {
        StartCoroutine(PostSettings());
        load.ClearOptions();
        StartCoroutine(GetSettings());
    }

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


        UnityWebRequest www = UnityWebRequest.Post(server + "add_simulation.php", form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("There was an error saving these settings, please try again later");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("The settings have been successfully saved!");
            Debug.Log("Upload complete!");
        }
        StartCoroutine(PostShops());
    }

    private IEnumerator PostShops()
    {
        foreach (var shop in mall.shops)
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

                UnityWebRequest www = UnityWebRequest.Post(server + "add_shop_position.php", form);
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log("There was an error saving the positioning, please try again later");
                    Debug.Log(www.error + "    simulation name:" + simulationName + "  shopName:" + shopName + "  position:" + positionID);
                }
                else
                {
                    Debug.Log("The position " + positionID + " has been successfully saved!");
                    Debug.Log("Upload complete!");
                }
            }
        }
    }

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
            mall.presets = JsonHelper.getJsonArray<Settings>(listData.downloadHandler.text).ToList<Settings>();
            var s = mall.presets.ToString();
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
                preset.Shops = JsonHelper.getJsonArray<Shop>(shopData.downloadHandler.text).ToList<Shop>();
            }
        }

        ShowPresets();
    }

    public void ShowPresets()
    {
        List<string> presetNames = new List<string>();
        foreach (var preset in mall.presets)
        {
            presetNames.Add(preset.Name);
        }
        load.AddOptions(presetNames);
    }

    public void SelectPreset()
    {
        Settings preset = mall.presets.Find(p => p.Name == load.captionText.text);
        startTime.text = preset.StartTime;
        endTime.text = preset.EndTime;
        holiday.value = holiday.options.FindIndex(option => option.text.ToLower() == preset.Holiday.ToLower());
        dayOfTheWeek.value = dayOfTheWeek.options.FindIndex(option => option.text.ToLower() == preset.DayOfTheWeek.ToLower());
        weather.value = weather.options.FindIndex(option => option.text.ToLower() == preset.Weather.ToLower());
        sale.value = sale.options.FindIndex(option => option.text.ToLower() == preset.Sales.ToLower());
        foreach (Shop shop in preset.Shops)
        {
            mall.swapping = true;
            mall.Swap(mall.shops.First(s => s.GetComponent<shopScript>().positionID == shop.PositionID));
            mall.Swap(mall.shops.First(s => s.GetComponent<shopScript>().shopName == shop.ShopName));
        }
    }

    public void SaveResults()
    {
        StartCoroutine(PostResults());
    }

    private IEnumerator PostResults()
    {
        WWWForm form = new WWWForm();
        Debug.Log("Customers: " + mall.totalCustomersLabel.text + "    Revenue: " + mall.totalRevenueLabel.text);
        form.AddField("TotalIncome", mall.totalRevenueLabel.text);
        form.AddField("TotalVisitors", mall.totalCustomersLabel.text);
        form.AddField("Duration", "not implemented");


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
            Debug.Log("The result has been successfully saved!");
            Debug.Log("Upload complete!");
        }
        StartCoroutine(PostShopsResult(resultID));

    }

    private IEnumerator PostShopsResult(int resultID)
    {
        if (resultID != -1)
        {
            foreach (var shop in mall.shops)
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
                        Debug.Log("The shop result has been successfully saved!");
                        Debug.Log("Upload complete!");
                    }
                }
            }
        }
        powerOff.StopSimulation();
    }

}
