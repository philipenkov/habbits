using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandedDay : MonoBehaviour
{
    public int Day { get; private set; }
    public string Month { get; private set; }
    public int Year { get; private set; }
    public string Info { get; private set; }

    public Image ColorFrame;

    private bool isFilled;

    public void SetExpandedDay(DateTime dateTime, string info, bool filled)
    {
        Day = dateTime.Day;
        Month = dateTime.Month.ToString("MMMM");
        Year = dateTime.Year;
        Info = info;
        isFilled = filled;
    }
}
