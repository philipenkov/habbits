using System;
using UnityEngine;

public class CurrentExtendedButtonSelector : MonoBehaviour
{
    public event Action<ExpandedDay> OnExpandedDaySelected;
    
    private ExpandedDay[] expandedDays;

    public void UpdateSelection(ExpandedDay expandedDay)
    {
        expandedDays = GetComponentsInChildren<ExpandedDay>();

        foreach (var day in expandedDays)
        {
            if (day == expandedDay)
            {
                day.SelectedBg.SwitchActivation(true);
                OnExpandedDaySelected?.Invoke(day);
                continue;
            }
            
            day.SelectedBg.SwitchActivation(false);
        }
    }
}
