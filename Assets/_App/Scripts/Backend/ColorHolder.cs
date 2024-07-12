using UnityEngine;
using UnityEngine.UI;

public class ColorHolder : MonoBehaviour
{
    public Color SelectedColor { get; private set; }

    public void SetColor(Color color)
    {
        SelectedColor = color;
    }

    private void OnEnable()
    {
        Toggle firstToggle = GetComponentInChildren<Toggle>();
        firstToggle.isOn = true;
        SelectedColor = firstToggle.targetGraphic.color;
    }
}
