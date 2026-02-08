using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PunchSystem : MonoBehaviour
{
    public GameObject[] modelGameObjects;
    public bool isTutorial = true;
    private bool isPunched = true;
    int randomPopupTime = 3;
    private GameObject currentActiveTarget;
    private BoxCollider boxCol;
    // Start is called before the first frame update


    
    void Start()
    {
        boxCol = this.gameObject.GetComponent<BoxCollider>();
        boxCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTutorial)
        {
            if (isPunched)
            {
                StartCoroutine(punchStart());
            }
            
        }
    }

    private IEnumerator punchStart()
    {
        
        yield return new WaitForSeconds(randomPopupTime);
        int x = Random.Range (0, modelGameObjects.Length);

        currentActiveTarget = modelGameObjects[x];
        currentActiveTarget.SetActive(true);        
        boxCol.enabled = true;
        isPunched = false;
        

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");

        if (!isTutorial)
        {
            if (collision.CompareTag("fist"))
            {
                
                currentActiveTarget.SetActive(false);
                StopAllCoroutines();
                randomPopupTime = Random.Range(1, 61);
                isPunched = true;
                boxCol.enabled = false;
                
            }
        }
    }

    public void StartTutorialPunch()
    {
        isTutorial = false;
    }


}
