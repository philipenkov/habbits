using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceButton : MonoBehaviour
{
    public CategoriesHolder CategoriesHolder;
    public GameObject CreateCategoryButton;
    public CategoriesReplacer CategoriesReplacer;
    
    private bool isActivated;
    
    public void SwitchReplace()
    {
        CreateCategoryButton.SetActive(isActivated);
        
        if (isActivated)
        {
            CategoriesReplacer.ResetReplacer();
        }

        isActivated = !isActivated;

        foreach (var category in CategoriesHolder.Categories)
        {
            category.SwitchReplaceToggle(isActivated);
        }
    }
}
