using UnityEngine;
using UnityEngine.UI;

public class ColorHolder : MonoBehaviour
{
    public bool SelectFirstColorOnEnable = true;
    public Color SelectedColor { get; private set; }

    private CustomToggleGroup customToggleGroup;

    private void Awake()
    {
        customToggleGroup = GetComponent<CustomToggleGroup>();
    }

    public void SetColor(Color color)
    {
        SelectedColor = color;
    }

    private void OnEnable()
    {
        if (!SelectFirstColorOnEnable)
            return;
        
        Toggle firstToggle = customToggleGroup.Toggles[0];
        SelectedColor = firstToggle.targetGraphic.color;
    }
}
