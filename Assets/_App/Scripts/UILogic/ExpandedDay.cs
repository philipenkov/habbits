using System.Globalization;
using _App.Scripts.UILogic;
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

    public void SetExpandedDay(DayInfo dayInfo)
    {
        Day = dayInfo.DateTime.Day;
        CultureInfo cultureInfo = new CultureInfo("en-US");
        Month = dayInfo.DateTime.ToString("MMMM", cultureInfo);
        Year = dayInfo.DateTime.Year;
        Info = dayInfo.Info;
        isFilled = dayInfo.IsFilled;
        
        SetButtonInfo(dayInfo.CategoryPanel.ColorTheme);
    }

    private void SetButtonInfo(Color colorTheme)
    {
        DateTMP.text = Day.ToString();
        MonthTMP.text = Month;
        YearTMP.text = Year.ToString();

        if (Info != null || Info != "")
            NotesIcon.enabled = true;
        else
            NotesIcon.enabled = false;

        if (isFilled)
        {
            ColorFrame.color = colorTheme;
        }
    }
}
