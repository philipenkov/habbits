using System;
using System.Collections.Generic;
using _App.Scripts.UILogic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    public TMP_Text Header;
    public TMP_Text Counter;
    public Button EditButton;
    
    [Space]
    public DayButton DayButtonPrefab;
    public Transform DaysPanel;

    private Queue<DayButton> dayButtons = new Queue<DayButton>();

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

    public void CreateDayButton()
    {
        DayButton dayButton = Instantiate(DayButtonPrefab, DaysPanel);

        DayInfo info = new DayInfo();
        info.Info = String.Empty;
        info.DateTime = DateTime.Now;
        info.IsFilled = false;

        dayButton.Init(info);
        // Если info.IsFilled = true;
       // dayButton.ChangeColor(ColorTheme);
    }

    private void OnDestroy()
    {
        EditButton.onClick.RemoveListener(Edit);
    }
}
