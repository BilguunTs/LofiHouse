using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ClockDegital : MonoBehaviour
{
    // Start is called before the first frame update
    private Text textClock;

    void Start()
    {
        textClock = GetComponent<Text>();

    }

    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        //textClock.text = hour + ":" + minute + ":" + second;
        textClock.text = hour +":"+ minute;
        textClock.resizeTextForBestFit = true;

    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
