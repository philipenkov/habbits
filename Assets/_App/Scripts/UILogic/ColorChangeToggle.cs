using UnityEngine;
using UnityEngine.UI;

public class ColorChangeToggle : MonoBehaviour
{
    private ColorHolder colorHolder;
    private Color color;

    private void Start()
    {
        colorHolder = GetComponentInParent<ColorHolder>();
        color = GetComponentInChildren<Image>().color;
    }

    public void SetColor(bool value)
    {
        if (value)
            colorHolder.SetColor(color);
    }
}
