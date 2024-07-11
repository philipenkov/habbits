using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateCategoryButton : MonoBehaviour
{
    public CategorySpawner CategorySpawner;
    public Image ColorPreviewImage;
    public TMP_InputField InputField;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SendDataToCategorySpawner);
        InputField.onValueChanged.AddListener(OnInputFieldChanged);
    }
    
    //TODO: сбрасывать интерактивность кнопки
    
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
        CategorySpawner.CreateCategory(InputField.text, ColorPreviewImage.color);
    }

    private void OnDestroy()
    {
        InputField.onValueChanged.RemoveListener(OnInputFieldChanged);
        button.onClick.RemoveListener(SendDataToCategorySpawner);
    }
}
