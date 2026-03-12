using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;
using JetBrains.Annotations;


public class MovementSystem : MonoBehaviour
{
    public enum type
    {
        linear,
        linearElevation,
        switchable
    }


    [Header("General Settings")]
    public float cartSpeed = 1f;
    public type trackType;
    public bool startPosition = false;
    public bool waitBeforeMoving = false;
    public float amountOfTimeWaiting = 3f;

    [Header("Objects Set Active Once Point Reached")]
    public GameObject[] objectsToActivate;

    //Linear:
    [Header("Linear Movement Settings")]
    public GameObject nextPosition;
    private GameObject cart;
    private bool startMoving = false;

    //Switchable:
    [Header("Switchable Movement Settings")]
    public SplineContainer splineContainerLeft;
    public GameObject nextPositionLeft;
    public SplineContainer splineContainerRight;
    public GameObject nextPositionRight;
    public SwitchButton switchButton;
    private bool useLeftTrack = true;
    private float distancePercentage = 0f;
    private float activationRadius = 0.5f;
    [Header("Objects Set Active Once Point Reached Switchable")]
    public GameObject[] objectsToActLeft;
    public GameObject[] objectsToActRight;




    // Start is called before the first frame update
    void Start()
    {
        cart = GameObject.Find("CART");

        if (startPosition)
        {
            MoveCartToNext();
        }


    }

    // Update is called once per frame
    void Update()
    {

        //Switchable activation check

        if (Vector3.Distance(cart.transform.position, this.transform.position) <= activationRadius && trackType == type.switchable)
        {
            if (switchButton != null)
            {
                switchButton.canBeSwitched = false;
            }

        }


        //Linear Movement
        if (startMoving && trackType == type.linear && waitBeforeMoving == false)
        {
            cart.transform.position = Vector3.MoveTowards(cart.transform.position, nextPosition.transform.position, cartSpeed * Time.deltaTime);
            cart.transform.LookAt(nextPosition.transform);
            if (cart.transform.position == nextPosition.transform.position)
            {
                startMoving = false;

                NextPosStart();
            }
        }

        //Switchable Movement
        else if (startMoving && trackType == type.switchable && waitBeforeMoving == false)
        {

            if (switchButton != null)
            {
                useLeftTrack = switchButton.isLeft;

                if (useLeftTrack)
                {
                    SwithcableTrack(splineContainerLeft);
                }
                else if (!useLeftTrack)
                {
                    SwithcableTrack(splineContainerRight);
                }
            }
        }


        //if you want to wait before moving
        if (waitBeforeMoving && Vector3.Distance(cart.transform.position, this.transform.position) <= activationRadius)
        {
            StartCoroutine(waitBeforeStartMoving());
        }

        //Objects set Active When Near Point

        //activate & Deactivates objects when reached next point
        if (objectsToActivate.Length > 0 && trackType == type.linear)
        {
            if (Vector3.Distance(cart.transform.position, this.transform.position) <= activationRadius)
            {
                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }
            }
            if (Vector3.Distance(cart.transform.position, nextPosition.transform.position) <= activationRadius && trackType == type.linear)
            {
                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(false);
                }
            }
        }
        else if (objectsToActLeft.Length > 0 && trackType == type.switchable && useLeftTrack)
        {
            if (Vector3.Distance(cart.transform.position, this.transform.position) <= activationRadius)
            {
                foreach (GameObject obj in objectsToActLeft)
                {
                    obj.SetActive(true);
                }
            }

        }
        else if (objectsToActRight.Length > 0 && trackType == type.switchable && !useLeftTrack)
        {
            if (Vector3.Distance(cart.transform.position, this.transform.position) <= activationRadius)
            {
                foreach (GameObject obj in objectsToActRight)
                {
                    obj.SetActive(true);
                }
            }
        }
    } 

    private IEnumerator waitBeforeStartMoving()
    {
        yield return new WaitForSeconds(amountOfTimeWaiting);
        waitBeforeMoving = false;
    }

    

    public void SwithcableTrack(SplineContainer spline)
    {
        float splineLength = spline.CalculateLength();

        distancePercentage += (cartSpeed * Time.deltaTime) / splineLength;
        distancePercentage = Mathf.Clamp01(distancePercentage);

        if (distancePercentage >= 1f)
        {
            startMoving = false;
            distancePercentage = 0f; 
            NextPosStart();
            return;
        }
        
        spline.Evaluate(distancePercentage, out float3 position, out float3 tangent, out float3 upVector);

        cart.transform.position = (Vector3)position;
        cart.transform.rotation = Quaternion.LookRotation((Vector3)tangent);

    }

    
 
    public void NextPosStart()
    {
        if(trackType == type.linear)
        {
            MovementSystem nextMoveSys = nextPosition.GetComponent<MovementSystem>();
            if (nextMoveSys != null)
            {
            nextMoveSys.MoveCartToNext();

            }
        }
        else if(trackType == type.switchable)
        {
            if (useLeftTrack)
            {
                MovementSystem nextMoveSys = nextPositionLeft.GetComponent<MovementSystem>();

                if (nextMoveSys != null)
                {
                    nextMoveSys.MoveCartToNext();
                }
            }
            else
            {
                MovementSystem nextMoveSys = nextPositionRight.GetComponent<MovementSystem>();

                if (nextMoveSys != null)
                {
                    nextMoveSys.MoveCartToNext();
                }
            }
        }
    }

  
    public void MoveCartToNext()
    {
        //moves cart to next position
        if (cart != null && nextPosition != null || splineContainerLeft != null && splineContainerRight != null)
        {
            
            //if the cart is at the next position it will get this position to stop effecting the cart 
            if (cart.transform.position == nextPosition.transform.position)
            {
                startMoving = false;
            }
            else
            {
                startMoving = true;
            }
            
        }
    }

    public void SkipWait()
    {
        waitBeforeMoving = false;
    }

   
}
