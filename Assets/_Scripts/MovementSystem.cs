using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public enum type
    {
        linear,
        linearElevation,
        switchable
    }

    public bool startPosition = false;

    public float cartSpeed = 5.0f;

    public type trackType;

    public GameObject nextPosition;

    private GameObject cart;

    private bool startMoving = false;

    


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
        if (startMoving)
        {
            cart.transform.position = Vector3.MoveTowards(cart.transform.position, nextPosition.transform.position, cartSpeed * Time.deltaTime);
        }
        if (cart.transform.position == nextPosition.transform.position)
        {
            startMoving = false;

            NextPosStart();
        }

    }

    public void MoveCartToNext()
    {
        if (cart != null && nextPosition != null)
        {
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

    public void NextPosStart()
    {
        MovementSystem nextMoveSys = nextPosition.GetComponent<MovementSystem>();
        if (nextMoveSys != null)
        {
            nextMoveSys.MoveCartToNext();
        }
    }
}
