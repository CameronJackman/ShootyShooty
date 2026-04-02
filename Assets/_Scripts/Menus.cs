using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    private Animator menuAnimator;

    public void menuClose()
    {
        menuAnimator.SetTrigger("StartClose");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.menuAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
