using System;
using System.Collections.Generic;
using _App.Scripts.UILogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    public TMP_Text Header;
    public TMP_Text Counter;
    public Button EditButton;

    [Space]
    public DaysPanel DaysPanel;

    public List<DayButton> DayButtons { get; private set; } = new List<DayButton>();


    public Color ColorTheme { get; private set; }

    private CategoryEditor categoryEditor;

    private void Start()
    {
        categoryEditor = FindObjectOfType<CategoryEditor>(true);
        EditButton.onClick.AddListener(Edit);
    }

    private void Edit()
    {
        categoryEditor.SetCategoryToEdit(this);
        ScreenStatesSwitcher.SwitchTo(Screens.CategoryEditor);
    }

    public void SetInfo(string headerText, Color color, int counterValue)
    {
        Header.text = headerText;
        Counter.text = counterValue.ToString();
        ColorTheme = color;
    }

    public void CreateEmptyDayButton(DateTime dateTime)
    {
        DayButton dayButton = DaysPanel.AddDayButton();
        DayInfo info = new DayInfo();
        info.Info = String.Empty;
        info.DateTime = dateTime;
        info.IsFilled = false;
        info.CategoryPanel = this;
        
        DayButtons.Add(dayButton);
        dayButton.Init(info);
    }

    public void LoadButton(DayButtonJSON dayButtonJson)
    {
        DayButton dayButton = DaysPanel.AddDayButton();

        DayInfo info = new DayInfo();
        DayInfoJSON jsonInfo = dayButtonJson.DayInfo;
        info.Info = jsonInfo.Info;
        info.DateTime = GetDateTimeFromLoadedJson(jsonInfo.DateTime);
        info.IsFilled = jsonInfo.IsFilled;
        info.CategoryPanel = this;
        
        DayButtons.Add(dayButton);
        dayButton.Init(info);
    }

    private DateTime GetDateTimeFromLoadedJson(DateTimeJSON dateTimeJson)
    {
        DateTime dateTime = new DateTime(dateTimeJson.Year, dateTimeJson.Month, dateTimeJson.Day);
        return dateTime;
    }

    private void OnDestroy()
    {
        EditButton.onClick.RemoveListener(Edit);
    }
}
