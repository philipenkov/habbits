using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpandedDay : MonoBehaviour
{
    public int Day { get; private set; }
    public string Month { get; private set; }
    public int Year { get; private set; }
    public string Info { get; private set; }

    public Image ColorFrame;

    public TMP_Text DateTMP;
    public TMP_Text MonthTMP;
    public TMP_Text YearTMP;
    public Image NotesIcon;

    private bool isFilled;

    public void SetExpandedDay(DateTime dateTime, string info, bool filled)
    {
        Day = dateTime.Day;
        CultureInfo cultureInfo = new CultureInfo("en-US");
        Month = dateTime.ToString("MMMM", cultureInfo);
        Year = dateTime.Year;
        Info = info;
        isFilled = filled;
        
        SetButtonInfo();
    }

    private void SetButtonInfo()
    {
        DateTMP.text = Day.ToString();
        MonthTMP.text = Month;
        YearTMP.text = Year.ToString();

        if (Info != null || Info != "")
            NotesIcon.enabled = true;
        else
            NotesIcon.enabled = false;
        
       //TODO:  if (isFilled) ColoredFrame
            
    }
}
