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


    // Start is called before the first frame update
    void Start()
    {
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
        
    }


}
