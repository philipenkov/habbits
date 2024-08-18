using System;
using UnityEngine;

public class CurrentExtendedButtonSelector : MonoBehaviour
{
    private ExpandedDay[] expandedDays;

    public void UpdateSelection(ExpandedDay expandedDay)
    {
        expandedDays = GetComponentsInChildren<ExpandedDay>();

        foreach (var day in expandedDays)
        {
            if (day == expandedDay)
            {
                day.SelectedBg.SwitchActivation(true);
                continue;
            }
            
            day.SelectedBg.SwitchActivation(false);
        }
    }
}
