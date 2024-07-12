using UnityEngine;
using UnityEngine.UI;

public class ColorChangeToggle : MonoBehaviour
{
    private ColorHolder colorHolder;
    private Color color;
    private CustomToggleGroup customToggleGroup;
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        colorHolder = GetComponentInParent<ColorHolder>();
        color = GetComponentInChildren<Image>().color;
        customToggleGroup = colorHolder.GetComponent<CustomToggleGroup>();
    }

    public void SetColor(bool value)
    {
        if (value)
        {
            colorHolder.SetColor(color);
            customToggleGroup.SwitchToToggle(toggle);
        }
    }
}
