using System;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesHolder : MonoBehaviour
{
    public event Action<List<CategoryPanel>> OnNewCategoriesChanged;
    
    public Transform SpawnParent;
    public GameObject CategoryPrefab;

    private List<CategoryPanel> categories = new List<CategoryPanel>();

    public void CreateCategory(string header, Color color, int counterValue = 0)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        categories.Add(categoryPanel);

        categoryPanel.CreateEmptyDayButton(); 
        SendCategoriesChangedEvent();
    }

    public void LoadCategory(string header, Color color, int counterValue, CategoryPanelJSON categoryPanelJson)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        categories.Add(categoryPanel);

        for (int i = 0; i < categoryPanelJson.DayButtons.Count; i++)
        {
            categoryPanel.LoadButton(categoryPanelJson.DayButtons[i]);
        }
    }

    public void DeleteCategory(CategoryPanel categoryPanel)
    {
        categories.Remove(categoryPanel);
        Destroy(categoryPanel.gameObject);
        SendCategoriesChangedEvent();
    }

    public void SendCategoriesChangedEvent()
    {
        OnNewCategoriesChanged?.Invoke(categories);
    }
}
