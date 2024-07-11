using UnityEngine;

public class SwitchScreenButton : MonoBehaviour
{
    public Screens TargetScreen;

    public void SwitchScreen()
    {
        ScreenStatesSwitcher.SwitchTo(TargetScreen);
    }
}
