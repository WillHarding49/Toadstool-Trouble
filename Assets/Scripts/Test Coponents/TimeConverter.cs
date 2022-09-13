using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConverter : MonoBehaviour
{
    protected string TimeToText(float currentTime)
    {
        //Time in secs / 60 to get the total minutes passed, made to an int so it get rids of any decimals, and converted to a double string
        string mins = ((int)currentTime / 60).ToString("00");

        //time in seconds converted to a string, but only to 2 decimal places
        string secs = (currentTime % 60).ToString("00.00");

        return "Time: " + mins + ":" + secs;
    }
}
