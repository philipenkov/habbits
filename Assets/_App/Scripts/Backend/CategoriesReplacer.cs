using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesReplacer : MonoBehaviour
{
    public CategoriesHolder CategoriesHolder;
    
    private int firstId;
    private bool isFirstSet;

    private int secondId;
    
    //TODO: при включении этого режима отключать все остальные кнопки

    private void Start()
    {
        ReplaceToggleControllerUtils.Init(this, CategoriesHolder);
    }

    public void RegisterID(int id)
    {
        if (!isFirstSet)
        {
            firstId = id;
            isFirstSet = true;
            return;
        }

        if (firstId != id)
        {
            secondId = id;
            Replace();
        }
        
        isFirstSet = false;
    }

    private void Replace()
    {
        CategoriesHolder.ReplaceCategory(firstId, secondId);
    }

    public void ResetReplacer()
    {
        isFirstSet = false;
    }
}
