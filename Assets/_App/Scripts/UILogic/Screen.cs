using UnityEngine;

public class Screen : MonoBehaviour
{
    public Screens ScreenType;
    public Animator ScreenAnimator;
    public string AnimationBoolName = "On";

    private bool isOn;

    public void SwitchActivation(bool value)
    {
        if (isOn == value)
            return;
        
        ScreenAnimator.SetBool(AnimationBoolName, value);
        isOn = value;
    }
}
