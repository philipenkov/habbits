using _App.Scripts.UILogic;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedDaySelectedBG : MonoBehaviour
{
    public Animator Animator;
    public string BoolName = "IsOn";
    public Image SelectedBG;

    public void Init(DayInfo dayInfo)
    {
        SelectedBG.color = dayInfo.CategoryPanel.ColorTheme;
    }

    public void SwitchActivation(bool value)
    {
        Animator.SetBool(BoolName, value);
    }
}
