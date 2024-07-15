using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateCategoryButton : MonoBehaviour
{
    public CategoriesHolder CategoriesHolder;
    public ColorHolder ColorHolder;
    public TMP_InputField InputField;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendDataToCategorySpawner);
        InputField.onValueChanged.AddListener(OnInputFieldChanged);
    }

    private void OnEnable()
    {
        ResetInput();
    }

    private void ResetInput()
    {
        if (button)
            button.interactable = false;
        
        InputField.text = string.Empty;
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

    private void SendDataToCategorySpawner()
    {
        Debug.Log(ColorHolder.SelectedColor);
        CategoriesHolder.CreateCategory(InputField.text, ColorHolder.SelectedColor);
    }

    private void OnDestroy()
    {
        InputField.onValueChanged.RemoveListener(OnInputFieldChanged);
        button.onClick.RemoveListener(SendDataToCategorySpawner);
    }
}
