using System;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesHolder : MonoBehaviour
{
    public event Action<CategoryPanel, int> OnNewCategoriesChanged;
    
    public Transform SpawnParent;
    public GameObject CategoryPrefab;

    public List<CategoryPanel> Categories { get; private set; } = new List<CategoryPanel>();

    public void CreateCategory(string header, Color color, int counterValue = 0)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        Categories.Add(categoryPanel);

        categoryPanel.CreateEmptyDayButton(); 
        SendCategoriesChangedEvent(categoryPanel);
    }

    public void LoadCategory(string header, Color color, int counterValue, CategoryPanelJSON categoryPanelJson)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        Categories.Add(categoryPanel);

        for (int i = 0; i < categoryPanelJson.DayButtons.Count; i++)
        {
            categoryPanel.LoadButton(categoryPanelJson.DayButtons[i]);
        }
    }

    public void DeleteCategory(CategoryPanel categoryPanel)
    {
        Categories.Remove(categoryPanel);
        Destroy(categoryPanel.gameObject);
        SendCategoriesChangedEvent(categoryPanel);
    }

    public void SendCategoriesChangedEvent(CategoryPanel categoryPanel)
    {
        OnNewCategoriesChanged?.Invoke(categoryPanel, Categories.IndexOf(categoryPanel));
    }
}
