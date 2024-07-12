using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggleGroup : MonoBehaviour
{
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
        SwitchToToggle(Toggles[0]);
    }

    private void OnDestroy()
    {
        
    }
}
