using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FinishEditCategoryButton : MonoBehaviour
{
    public ColorHolder ColorHolder;
    public TMP_InputField InputField;
    public CategoryEditor CategoryEditor;
    
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SaveEdit);
        InputField.onValueChanged.AddListener(OnInputFieldChanged);
    }
    
    private void OnInputFieldChanged(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    private void SaveEdit()
    {
        CategoryEditor.Save(InputField.text, ColorHolder.SelectedColor);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(SaveEdit);
    }
}
