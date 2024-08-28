using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesHolder : MonoBehaviour
{
    public event Action<CategoryPanel, int> OnNewCategoriesChanged;
    public event Action<CategoryPanel, int> OnCategoryDeleted;
    
    public Transform SpawnParent;
    public GameObject CategoryPrefab;

    public List<CategoryPanel> Categories { get; private set; } = new List<CategoryPanel>();

    public void CreateCategory(string header, Color color, int counterValue = 0)
    {
        GameObject categoryObject = Instantiate(CategoryPrefab, SpawnParent);
        CategoryPanel categoryPanel = categoryObject.GetComponent<CategoryPanel>();
        categoryPanel.SetInfo(header, color, counterValue);
        Categories.Add(categoryPanel);

        categoryPanel.CreateEmptyDayButton(DateTime.Now); 
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
        int formerId = Categories.IndexOf(categoryPanel);
        Categories.Remove(categoryPanel);
        Destroy(categoryPanel.gameObject);
        OnCategoryDeleted?.Invoke(categoryPanel, formerId);
    }

    public void SendCategoriesChangedEvent(CategoryPanel categoryPanel)
    {
        OnNewCategoriesChanged?.Invoke(categoryPanel, Categories.IndexOf(categoryPanel));
    }

    public void ReplaceCategory(int replacingId, int idToReplace)
    {
        // Проверка допустимости индексов
        if (replacingId < 0 || replacingId >= Categories.Count || idToReplace < 0 || idToReplace > Categories.Count)
        {
            Debug.LogWarning("Invalid indices provided for replacing or inserting categories.");
            return;
        }

        // Извлекаем объект, который нужно переместить
        CategoryPanel categoryToMove = Categories[replacingId];
        Categories[idToReplace].ReplaceToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(false);

        // Удаляем его из списка
        Categories.RemoveAt(replacingId);
        
        // Вставляем объект в новое место
        Categories.Insert(idToReplace, categoryToMove);
        categoryToMove.transform.SetSiblingIndex(idToReplace);
        categoryToMove.ReplaceToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
    }
}
