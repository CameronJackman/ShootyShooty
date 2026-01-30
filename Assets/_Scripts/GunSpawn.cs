using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour
{

    public GameObject gunSpawnPoint;

    private GameObject gun;


    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindWithTag("gun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("gun"))
        {
            respawnGun();
        }
    }


    void respawnGun()
    {
        if (gunSpawnPoint != null && gun != null)
        {
            gun.transform.position = gunSpawnPoint.transform.position;
        }
    }
}
