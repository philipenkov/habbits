using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ButtonClickRecieverUtils.OnClicked += PlayClick;
    }

    private void PlayClick()
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {
        ButtonClickRecieverUtils.OnClicked -= PlayClick;
    }
}
