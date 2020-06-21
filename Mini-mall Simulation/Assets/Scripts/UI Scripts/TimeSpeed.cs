using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpeed : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1;
    }
    public void Speed3()
    {
        Time.timeScale = 5;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Speed2()
    {
        Time.timeScale = 3;
    }
}
