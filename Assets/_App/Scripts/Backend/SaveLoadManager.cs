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
    public event Action OnLoaded;
    
    [HideInInspector]
    public CategoriesHolderJSON CategoriesHolderJson = new CategoriesHolderJSON();
    public CategoriesHolder CategoriesHolder;

    private CurrentDayInfoPanel currentDayInfoPanel;

    private void Start()
    {
        currentDayInfoPanel = FindObjectOfType<CurrentDayInfoPanel>(true);
        CategoriesHolderJson.Categories = new List<CategoryPanelJSON>();
        CategoriesHolder.OnNewCategoriesChanged += SaveCategory;
        CategoriesHolder.OnCategoryDeleted += SaveCategoryDeletion;
        currentDayInfoPanel.OnInfoChanged += SaveDayInfo;
        LoadCategories();
    }
    
    //======================SAVE:=========================

    private void SaveCategoryDeletion(CategoryPanel categoryPanel, int formerId)
    {
        CategoriesHolderJson.Categories.RemoveAt(formerId);
        SaveToPath();
    }

    public void SaveCategory(CategoryPanel categoryPanel, int categoryId)
    {
        SaveCategoryById(categoryPanel, categoryId);
        SaveToPath();
    }

    public void SaveCategoryAfterNewDaysCreated(CategoryPanel categoryPanel, int categoryId)
    {
        SaveCategoryById(categoryPanel, categoryId, true);
        SaveToPath();
    }

    private void SaveToPath()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "nhabits_save.json");
        SaveToJson(path);
    }
    
    private void SaveToJson(string path)
    {
        string json = JsonUtility.ToJson(CategoriesHolderJson, true);
        System.IO.File.WriteAllText(path, json);
        Debug.Log("JSON saved: " + json);
    }

    private void SaveCategoryById(CategoryPanel categoryPanel, int id, bool saveDays = false)
    {
        List<CategoryPanelJSON> categoriesJson = CategoriesHolderJson.Categories;
        int newId = 0;
        bool isNewCategory = false;

        if (id >= categoriesJson.Count)
        {
            newId = categoriesJson.Count;
            categoriesJson.Add(new CategoryPanelJSON());
            isNewCategory = true;
        }
        else
        {
            newId = id;
        }

        categoriesJson[newId].Color = categoryPanel.ColorTheme;
        categoriesJson[newId].Count = categoryPanel.Counter.text;
        categoriesJson[newId].Header = categoryPanel.Header.text;

        if (!isNewCategory && !saveDays)
        {
            return;
        }
        
        categoriesJson[newId].DayButtons = new List<DayButtonJSON>();
        for (int j = 0; j < categoryPanel.DayButtons.Count; j++)
        {
            DayButtonJSON dayButtonJson = new DayButtonJSON();
            dayButtonJson.DayInfo = GetDayInfoJson(categoryPanel.DayButtons[j].DayInfo);
            categoriesJson[newId].DayButtons.Add(dayButtonJson);
        }
    }

    public void SaveDayInfo(DayInfo dayInfo)
    {
        CategoryPanel categoryPanel = dayInfo.CategoryPanel;
        var dayButton = categoryPanel.DayButtons.Find(button => button.DayInfo == dayInfo);
        var dayId = categoryPanel.DayButtons.IndexOf(dayButton);
        int categoryId = CategoriesHolder.Categories.IndexOf(categoryPanel);
        DayInfoJSON dayInfoJson = CategoriesHolderJson.Categories[categoryId].DayButtons[dayId].DayInfo;
        dayInfoJson.Info = dayInfo.Info;
        dayInfoJson.IsFilled = dayInfo.IsFilled;
        
        SaveToPath();
    }

    //======================LOAD:=========================

    public bool LoadCategories()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "nhabits_save.json");
        return LoadFromJson(path);
    }

    private bool LoadFromJson(string path)
    {
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            CategoriesHolderJson = JsonUtility.FromJson<CategoriesHolderJSON>(json);
            TransferJsonToCategories();
            OnLoaded?.Invoke();
            return true;
        }
        else
        {
            return false;
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
        CategoriesHolder.OnNewCategoriesChanged -= SaveCategory;
        currentDayInfoPanel.OnInfoChanged -= SaveDayInfo;
        CategoriesHolder.OnCategoryDeleted -= SaveCategoryDeletion;
    }
}

