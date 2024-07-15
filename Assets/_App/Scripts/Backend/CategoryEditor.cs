using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryEditor : MonoBehaviour
{
    public TMP_InputField CategoryNameField;
    public CategoriesHolder CategoriesHolder;
    public ColorChangeToggle[] ColorChangeToggles;
    
    private CategoryPanel categoryPanelToEdit;
    
    public void SetCategoryToEdit(CategoryPanel categoryPanel)
    {
        categoryPanelToEdit = categoryPanel;
        CategoryNameField.text = categoryPanel.Header.text;
        SetColorToggle(categoryPanel.ColorTheme);
    }

    private void SetColorToggle(Color neededColor)
    {
        foreach (var toggle in ColorChangeToggles)
        {
            if (toggle.Color != neededColor)
                continue;
            
            toggle.GetComponent<Toggle>().isOn = true;
            return;
        }
    }

    public void DeleteCategory()
    {
        CategoriesHolder.DeleteCategory(categoryPanelToEdit);
    }

    public void Save(string newName, Color newColor)
    {
        categoryPanelToEdit.SetInfo(newName, newColor, Int32.Parse(categoryPanelToEdit.Counter.text));
    }
}
