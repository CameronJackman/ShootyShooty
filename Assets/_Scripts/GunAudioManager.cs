using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip gunTarget, gunWater, gunButton, gunShot;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found in GunSounds GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitWater()
    {
        if (audioSource != null && gunWater != null)
        {
            audioSource.PlayOneShot(gunWater);
        }
    }

    public void HitTarget()
    {
        if (audioSource != null && gunTarget != null)
        {
            audioSource.PlayOneShot(gunTarget);
        }
    }

    public void HitButton()
    {
        if (audioSource != null && gunButton != null)
        {
            audioSource.PlayOneShot(gunButton);
        }
    }

    public void ShootAudio()
    {
        if (audioSource != null && gunShot != null)
        {
            audioSource.PlayOneShot(gunShot);
        }
    }
}
