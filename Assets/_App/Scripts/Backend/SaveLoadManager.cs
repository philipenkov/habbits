using System;
using System.Collections.Generic;
using _App.Scripts.UILogic;
using UnityEngine;

[Serializable]
public class CategoriesHolderJSON
{
    public List<CategoryPanelJSON> Categories;
}

[Serializable]
public class CategoryPanelJSON
{
    public string Header;
    public string Count;
    public Color Color;
    public List<DayButtonJSON> DayButtons;
}

[Serializable]
public class DayButtonJSON
{
    public DayInfoJSON DayInfo;
}

[Serializable]
public class DayInfoJSON
{
    public DateTimeJSON DateTime;
    public bool IsFilled;
    public string Info;
}

[Serializable]
public class DateTimeJSON
{
    public int Year;
    public int Month;
    public int Day;
}


public class SaveLoadManager : MonoBehaviour
{
    [HideInInspector]
    public CategoriesHolderJSON CategoriesHolderJson = new CategoriesHolderJSON();
    public CategoriesHolder CategoriesHolder;

    private void Start()
    {
        CategoriesHolderJson.Categories = new List<CategoryPanelJSON>();
        CategoriesHolder.OnNewCategoriesChanged += SaveCategories;
        LoadCategories();
    }
    
    public void SaveCategories(List<CategoryPanel> categoryPanels)
    {
        FillCategoriesJson(categoryPanels);
        string path = System.IO.Path.Combine(Application.persistentDataPath, "nhabits_save.json");
        SaveToJson(path);
    }

    public bool LoadCategories()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "nhabits_save.json");
        return LoadFromJson(path);
    }

    private void SaveToJson(string path)
    {
        string json = JsonUtility.ToJson(CategoriesHolderJson, true);
        System.IO.File.WriteAllText(path, json);
        Debug.Log("JSON saved: " + json);
    }

    private bool LoadFromJson(string path)
    {
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            CategoriesHolderJson = JsonUtility.FromJson<CategoriesHolderJSON>(json);
            TransferJsonToCategories();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FillCategoriesJson(List<CategoryPanel> categoryPanels)
    {
        List<CategoryPanelJSON> categoriesJson = CategoriesHolderJson.Categories;
        categoriesJson.Clear();
        
        for (int i = 0; i < categoryPanels.Count; i++)
        {
            categoriesJson.Add(new CategoryPanelJSON());
            categoriesJson[i].Color = categoryPanels[i].ColorTheme;
            categoriesJson[i].Count = categoryPanels[i].Counter.text;
            categoriesJson[i].Header = categoryPanels[i].Header.text;
            categoriesJson[i].DayButtons = new List<DayButtonJSON>();

            for (int j = 0; j < categoryPanels[i].DayButtons.Count; j++)
            {
                DayButtonJSON dayButtonJson = new DayButtonJSON();
                dayButtonJson.DayInfo = GetDayInfoJson(categoryPanels[i].DayButtons[j].DayInfo);
                categoriesJson[i].DayButtons.Add(dayButtonJson);
            }
        }
    }

    private void TransferJsonToCategories()
    {
        List<CategoryPanelJSON> categoriesJson = CategoriesHolderJson.Categories;

        for (int i = 0; i < categoriesJson.Count; i++)
        {
            CategoriesHolder.LoadCategory(categoriesJson[i].Header, categoriesJson[i].Color, 
                int.Parse(categoriesJson[i].Count), categoriesJson[i]);
        }
    }

    private DayInfoJSON GetDayInfoJson(DayInfo dayInfo)
    {
        DayInfoJSON dayInfoJson = new DayInfoJSON();
        dayInfoJson.Info = dayInfo.Info;
        dayInfoJson.DateTime = GetDateTimeJson(dayInfo.DateTime);
        dayInfoJson.IsFilled = dayInfo.IsFilled;
        return dayInfoJson;
    }

    private DateTimeJSON GetDateTimeJson(DateTime dateTime)
    {
        DateTimeJSON dateTimeJson = new DateTimeJSON();
        dateTimeJson.Day = dateTime.Day;
        dateTimeJson.Month = dateTime.Month;
        dateTimeJson.Year = dateTime.Year;
        return dateTimeJson;
    }

    private void OnDestroy()
    {
        CategoriesHolder.OnNewCategoriesChanged -= SaveCategories;
    }
}

