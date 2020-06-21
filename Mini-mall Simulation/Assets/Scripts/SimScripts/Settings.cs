using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class Settings
{
    public TMP_InputField name;
    public TMP_InputField startTime;
    public TMP_InputField endtime;
    public TMP_Dropdown weather;
    public TMP_Dropdown holiday;
    public TMP_Dropdown dayOfTheWeek;
    public TMP_Dropdown sales;
    [HideInInspector] // Hides var below
    public string Name;
    [HideInInspector] // Hides var below
    public string StartTime;
    [HideInInspector] // Hides var below
    public string EndTime;
    [HideInInspector] // Hides var below
    public string Weather;
    [HideInInspector] // Hides var below
    public string Holiday;
    [HideInInspector] // Hides var below
    public string DayOfTheWeek;
    [HideInInspector] // Hides var below
    public string Sales;
    [HideInInspector] // Hides var below
    public List<ShopPlacement> Shops;
    private string Duration;

    public Settings(string Name, string StartTime, string EndTime, string Weather, string Holiday, string DayOfTheWeek, string Sales, List<ShopPlacement> shops)
    {
        this.Name = Name;
        this.StartTime = StartTime;
        this.EndTime = EndTime;
        this.Weather = Weather;
        this.Holiday = Holiday;
        this.DayOfTheWeek = DayOfTheWeek;
        this.Sales = Sales;
        this.Shops = shops;
        GetDuration();
    }

    public Settings(string Name, string StartTime, string EndTime, string Weather, string Holiday, string DayOfTheWeek, string Sales)
    {
        this.Name = Name;
        this.StartTime = StartTime;
        this.EndTime = EndTime;
        this.Weather = Weather;
        this.Holiday = Holiday;
        this.DayOfTheWeek = DayOfTheWeek;
        this.Sales = Sales;
        GetDuration();
    }

    public void Assign()
    {
        Name = name.text;
        StartTime = startTime.text;
        EndTime = endtime.text;
        Weather = weather.options[weather.value].text;
        Holiday = holiday.options[holiday.value].text;
        DayOfTheWeek = dayOfTheWeek.options[dayOfTheWeek.value].text;
        Sales = sales.options[sales.value].text;
        Duration = GetDuration();
    }

    public string GetDuration()
    {
        TimeSpan duration;
        try
        {
            duration = DateTime.ParseExact(EndTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture) -
                        DateTime.ParseExact(StartTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (FormatException ex)
        {
            Debug.Log("Please enter the correct time format");
        }
        Duration = duration.TotalMinutes.ToString();
        return Duration;
    }

    public string GetDuration(string endTime)
    {
        TimeSpan duration;
        try
        {
            duration = DateTime.ParseExact(endTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture) -
                        DateTime.ParseExact(StartTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (FormatException ex)
        {
            Debug.Log("Please enter the correct time format");
            return null;
        }
        Duration = duration.TotalMinutes.ToString();
        return Duration;
    }
}
