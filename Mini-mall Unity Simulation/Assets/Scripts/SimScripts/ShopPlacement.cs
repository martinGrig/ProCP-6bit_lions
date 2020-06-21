using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopPlacement
{
    public string SimulationName;
    public string ShopName;
    public int PositionID;

    public ShopPlacement(string simulationName, string shopName, int position)
    {
        SimulationName = simulationName;
        ShopName = shopName;
        PositionID = position;
    }
}
