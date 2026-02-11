using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopPlayer : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;

    public Animator fistAnimator;

    private float yRotation = 0f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        if (Input.GetMouseButtonDown(1))
        {
            PunchForward();
        }
    }

    void PunchForward()
    {
        fistAnimator.SetTrigger("isPunch");
    }
}
