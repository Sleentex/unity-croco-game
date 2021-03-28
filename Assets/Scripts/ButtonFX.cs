using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hoverAudio;
    public AudioClip clickAudio;
    
    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverAudio);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickAudio);
    }
}
