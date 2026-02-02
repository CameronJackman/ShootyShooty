using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{

    public Animator leverAnimator;

    public bool isLeft = true;
    public bool canBeSwitched = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this updates the animation of the levers direction when theres a change in direction
        AnimationUpdate();


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet") && canBeSwitched)
        {
           SwitchLeft(); 
        }
        
    }


    void SwitchLeft()
    {
        if (isLeft)
            {
                //Switches the lever to the right
                isLeft = false;
            }
            else if (!isLeft)
            {
                //Switches the lever to the left
                isLeft = true;
                
                
            }
    }

    void AnimationUpdate()
    {
        if (isLeft)
        {
            leverAnimator.SetBool("isLeft", true);
        }
        else if (!isLeft)
        {
            leverAnimator.SetBool("isLeft", false);
        }
    }

}



