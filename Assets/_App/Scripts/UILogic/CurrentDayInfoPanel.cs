using TMPro;
using UnityEngine;

public class CurrentDayInfoPanel : MonoBehaviour
{
    public TMP_Text Day;
    public TMP_Text Month;
    public TMP_Text Year;
    public TMP_InputField Info;
    
    public void Set(ExpandedDay expandedDay)
    {
        Day.text = expandedDay.Day.ToString();
        Month.text = expandedDay.Month;
        Year.text = expandedDay.Year.ToString();
        Info.text = expandedDay.Info;
    }
}
