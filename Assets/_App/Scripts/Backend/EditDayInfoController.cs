using System;
using _App.Scripts.UILogic;
using UnityEngine;

public class EditDayInfoController : MonoBehaviour
{
    public event Action<DayInfo> OnInfoPanelSet;
    
    public CurrentDayInfoPanel CurrentDayInfoPanel;
    
    public void SetDayInfo(DayInfo dayInfo)
    {
        CurrentDayInfoPanel.Set(dayInfo);
        OnInfoPanelSet?.Invoke(dayInfo);
    }
}
