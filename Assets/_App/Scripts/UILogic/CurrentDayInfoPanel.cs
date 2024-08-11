using System;
using System.Globalization;
using _App.Scripts.UILogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentDayInfoPanel : MonoBehaviour
{
    public event Action<DayInfo> OnInfoChanged;
    
    public TMP_Text Day;
    public TMP_Text Month;
    public TMP_Text Year;
    public TMP_InputField Info;
    public Image ColorStripe;
    public DaysExpandedPanel DaysExpandedPanel;
    public Button ClearButton;

    private DayInfo currentDayInfo;

    public void Set(ExpandedDay expandedDay)
    {
        Day.text = expandedDay.Day.ToString();
        Month.text = expandedDay.Month;
        Year.text = expandedDay.Year.ToString();
        Info.text = expandedDay.Info;
    }
    
    public void Set(DayInfo dayInfo)
    {
        Day.text = dayInfo.DateTime.Day.ToString();
        CultureInfo cultureInfo = new CultureInfo("en-US");
        Month.text = dayInfo.DateTime.ToString("MMMM", cultureInfo);
        Year.text = dayInfo.DateTime.Year.ToString();
        Info.text = dayInfo.Info;
        currentDayInfo = dayInfo;
        ColorStripe.color = dayInfo.CategoryPanel.ColorTheme;

        ClearButton.gameObject.SetActive(dayInfo.IsFilled);
    }

    public void DoneEditingDay()
    {
        Color colorToSet = currentDayInfo.CategoryPanel.ColorTheme;
        currentDayInfo.IsFilled = true;
        currentDayInfo.Info = Info.text;
        DayButton dayButton = currentDayInfo.CategoryPanel.DayButtons.Find(button => button.DayInfo == currentDayInfo);
        dayButton.ChangeColor(colorToSet);
        ExpandedDay expandedDay = DaysExpandedPanel.ExpandedDays.Find(day => day.LinkedDayInfo == currentDayInfo);
        expandedDay.ChangeColor(colorToSet);
        expandedDay.SwitchNotesIcon(!string.IsNullOrEmpty(currentDayInfo.Info));
        currentDayInfo.CategoryPanel.UpdateCombo();
        OnInfoChanged?.Invoke(currentDayInfo);
    }

    public void ClearDay()
    {
        currentDayInfo.IsFilled = false;
        currentDayInfo.Info = "";
        Info.text = "";
        DayButton dayButton = currentDayInfo.CategoryPanel.DayButtons.Find(button => button.DayInfo == currentDayInfo);
        dayButton.ChangeColor(dayButton.DefaultColor);
        ExpandedDay expandedDay = DaysExpandedPanel.ExpandedDays.Find(day => day.LinkedDayInfo == currentDayInfo);
        expandedDay.ChangeColor(expandedDay.DefaultColor);
        expandedDay.SwitchNotesIcon(false);
        currentDayInfo.CategoryPanel.UpdateCombo();
        ClearButton.gameObject.SetActive(false);
        OnInfoChanged?.Invoke(currentDayInfo);
    }
}
