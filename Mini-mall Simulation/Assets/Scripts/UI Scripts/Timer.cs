using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private double hours;
    private double minutes;
    public TextMeshProUGUI h;
    public TextMeshProUGUI m;
    public TextMeshProUGUI start;
    public TextMeshProUGUI end;
    public Button stopSimulation;
    public SimulationSwitch sim;

    public bool optimizing;

    private bool finalHour;

    private void Start()
    {
        try
        {
            minutes = Convert.ToDouble(start.text.Substring(3, 2));
            hours = Convert.ToDouble(start.text.Substring(0, 2));
            h.text = hours.ToString().PadLeft(2, '0');
        }
        catch(Exception)
        {
            Debug.Log("Please enter a correct time format!");
        }
    }

    public void Restart()
    {
        try
        {
            minutes = Convert.ToDouble(start.text.Substring(3, 2));
            hours = Convert.ToDouble(start.text.Substring(0, 2));
            h.text = hours.ToString().PadLeft(2, '0');
        }
        catch (Exception)
        {
            Debug.Log("Please enter a correct time format!");
        }
    }

    private void Update()
    {
        minutes += Time.deltaTime*2;
        if(minutes >= 60)
        {
            minutes = 0;
            Hour();
        }
        if(minutes > 10)
        {
            m.text = minutes.ToString().Substring(0, 2);
        }
        else
        {
            m.text = minutes.ToString().Substring(0,1).PadLeft(2,'0');
        }

        if(finalHour)
        {
            if(minutes >= Convert.ToDouble(end.text.Substring(3,2)))
            {
                sim.StopSimulation();
                finalHour = false;
            }
        }
    }

    private void Hour()
    {
        hours += 1;

        if(hours >= 24)
        {
            hours = 00;
        }
        h.text = hours.ToString().PadLeft(2, '0');

        if(hours >= Convert.ToDouble(end.text.Substring(0,2)))
        {
            finalHour = true;
        }
    }
}
