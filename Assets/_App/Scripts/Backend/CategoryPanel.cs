using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    public TMP_Text Header;
    public TMP_Text Counter;
    public Button EditButton;
    
    //private Queue<>

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

    private void OnDestroy()
    {
        EditButton.onClick.RemoveListener(Edit);
    }
}
