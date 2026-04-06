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
    float j = 0f;
    private GameMan gameManager;
    bool coruStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        boxCol = this.gameObject.GetComponent<BoxCollider>();
        boxCol.enabled = false;
        gameManager = FindAnyObjectByType<GameMan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTutorial)
        {
            if (isPunched)
            {   
                if (!coruStarted)
                {
                    StartCoroutine(punchStart());
                }
                
            }
            
        }
    }

    private IEnumerator punchStart()
    {
        coruStarted = true;
        yield return new WaitForSeconds(randomPopupTime);
        int x = Random.Range (0, modelGameObjects.Length);

        currentActiveTarget = modelGameObjects[x];
        currentActiveTarget.SetActive(true);        
        boxCol.enabled = true;
        isPunched = false;
        
        j += Time.deltaTime;
        if (j >= 1.5f)
        {
            //minus 10 points 
            gameManager.points -= 10;
            j = 0f;
        }
        

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
                randomPopupTime = Random.Range(20, 80);
                isPunched = true;
                boxCol.enabled = false;
                coruStarted = false;
            }
        }
    }

    public void StartTutorialPunch()
    {
        isTutorial = false;
    }


}
