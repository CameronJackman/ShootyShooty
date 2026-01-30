using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class MenuAudioManager : MonoBehaviour
{

    private AudioSource audiosource;

    public AudioClip menuSelectSound;

    public AudioClip menuHoverSound;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        if (audiosource == null)
        {
            Debug.LogError("AudioSource component not found on MenuAudioManager GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySelectSound()
    {
        if (audiosource != null && menuSelectSound != null)
        {
            audiosource.PlayOneShot(menuSelectSound);
        }
    }

    public void PlayHoverSound()
    {
        if (audiosource != null && menuHoverSound != null)
        {
            audiosource.PlayOneShot(menuHoverSound);
        }
    }
}
