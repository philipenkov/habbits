using System.Collections;
using System.Collections.Generic;
using _App.Scripts.UILogic;
using UnityEngine;

public class EditDayInfoController : MonoBehaviour
{
    public CurrentDayInfoPanel CurrentDayInfoPanel;
    
    public void SetDayInfo(DayInfo dayInfo)
    {
        CurrentDayInfoPanel.Set(dayInfo);
    }
}
