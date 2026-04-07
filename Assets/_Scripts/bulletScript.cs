using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private GunAudioManager audioManager;
    private GameMan gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameMan>();

        audioManager = FindAnyObjectByType<GunAudioManager>();

        if (audioManager != null)
        {
            audioManager.ShootAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioManager != null)
        {
            if (collision.collider.CompareTag("water"))
            {
                audioManager.HitWater();
            }
            else if (collision.collider.CompareTag("cutout"))
            {
                audioManager.HitTarget();
            }
            else if (collision.collider.CompareTag("target"))
            {
                audioManager.HitButton();

                gameManager.shotsHitAmt++;
                
            }
        }
    }
}
