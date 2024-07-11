using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CategoryPanel : MonoBehaviour
{
    public TMP_Text Header;
    public TMP_Text Counter;
    
    //private Queue<>

    public Color ColorTheme { get; private set; }

    public void SetInfo(string headerText, Color color, int counterValue)
    {
        Header.text = headerText;
        Counter.text = counterValue.ToString();
        ColorTheme = color;
    }
}
