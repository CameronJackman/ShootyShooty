using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockedCursorInput : StandaloneInputModule
{
    protected override MouseState GetMousePointerEventData(int id)
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            try
            {
                Cursor.lockState = CursorLockMode.Confined;
                return base.GetMousePointerEventData(id);
            }
            finally
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
        return base.GetMousePointerEventData(id);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
