using System;

public static class ButtonClickRecieverUtils
{
    public static event Action OnClicked;

    public static void NotifyAboutClick()
    {
        OnClicked?.Invoke();
    }
}
