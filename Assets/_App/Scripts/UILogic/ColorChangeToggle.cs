using UnityEngine;
using UnityEngine.UI;

public class ColorChangeToggle : MonoBehaviour
{
    public Color Color { get; private set; }
    
    private ColorHolder colorHolder;
    private CustomToggleGroup customToggleGroup;
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        colorHolder = GetComponentInParent<ColorHolder>();
        Color = GetComponentInChildren<Image>().color;
        customToggleGroup = colorHolder.GetComponent<CustomToggleGroup>();
    }

    public void SetColor(bool value)
    {
        if (value)
        {
            colorHolder.SetColor(Color);
            customToggleGroup.SwitchToToggle(toggle);
        }
    }
}
