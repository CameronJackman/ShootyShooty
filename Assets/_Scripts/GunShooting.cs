using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
public class GunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public GameObject gunBarrel;

    public int bulletSpeed;

    private GameMan gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameMan>();
        
        //this will return as an error when playing desktop because the vr rig isnt active
        //just ignore, the game works fine with this 
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => Shoot());
        
        
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {

            GameObject newBullet = Instantiate(bulletPrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(gunBarrel.transform.forward * bulletSpeed);

            Destroy(newBullet, 5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isVr)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }


}
