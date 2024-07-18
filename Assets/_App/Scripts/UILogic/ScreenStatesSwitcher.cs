using System;
using UnityEngine;

public enum Screens
{
    Main,
    CategoryCreator,
    CategoryEditor,
    EditDay
}

public class ScreenStatesSwitcher : MonoBehaviour
{
    public Screen[] AllScreens;
    
    private static Screen[] screensCollection;

    private void Awake()
    {
        screensCollection = AllScreens;
        SwitchTo(Screens.Main);
    }

    public static void SwitchTo(Screens targetScreen)
    {
        foreach (var screen in screensCollection)
        {
            screen.SwitchActivation(screen.ScreenType == targetScreen);
        }
    }
}
