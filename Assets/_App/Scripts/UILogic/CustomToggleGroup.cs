using UnityEngine;
using UnityEngine.UI;

public class CustomToggleGroup : MonoBehaviour
{
    public bool SelectFirstOnEnable = true;
    public Toggle[] Toggles;

    public void SwitchToToggle(Toggle targetToggle)
    {
        foreach (var toggle in Toggles)
        {
            toggle.isOn = toggle == targetToggle;
        }
    }

    private void OnEnable()
    {
        if (!SelectFirstOnEnable)
            return;
        
        SwitchToToggle(Toggles[0]);
    }
}
