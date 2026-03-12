using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            ReloadCurrentScene();
            
        }
    }

    public void ReloadCurrentScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
