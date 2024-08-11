using UnityEngine;
using UnityEngine.UI;

public class SFXSoundSender : MonoBehaviour
{
    public Button Button;

    private void Start()
    {
        Button.onClick.AddListener(SendSFXEvent);
    }

    private void SendSFXEvent()
    {
        ButtonClickRecieverUtils.NotifyAboutClick();
    }

    private void OnDestroy()
    {
        Button.onClick.RemoveListener(SendSFXEvent);
    }
}
