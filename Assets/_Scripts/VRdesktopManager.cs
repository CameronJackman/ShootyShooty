using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEditor.XR.OpenXR;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRdesktopManager : MonoBehaviour
{
    public GameObject DesktopPlayerPrefab;
    public GameObject vrPlayerPrefab;
    public GameObject VRSelectMenu;
    private GameObject activePlayer;
    private GameMan gameManager;

    private void Awake()
    {
        if (VRSelectMenu != null)
        {
            VRSelectMenu.SetActive(true);
        }
        gameManager = FindAnyObjectByType<GameMan>();
    }

    public void StartXR()
    {
        StartCoroutine(EnableXR());
    }
    public IEnumerator EnableXR()
    {
        Debug.Log("Starting XR");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Failed to start XR Loader");
            yield break;
        }

        Debug.Log("Starting XR SubSystems");
        XRGeneralSettings.Instance.Manager.StartSubsystems();
    }

    public void StopXR()
    {
        if (XRGeneralSettings.Instance.Manager.isInitializationComplete)
        {
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            Debug.Log("XR stopped and deinitialized");
        }
    }

    public void VRSelection()
    {
        DesktopPlayerPrefab.SetActive(false);
        vrPlayerPrefab.SetActive(true);
        gameManager.isVr = true;
    }
    public void DesktopSelection()
    {
        DesktopPlayerPrefab.SetActive(true);
        vrPlayerPrefab.SetActive(false);
        gameManager.isVr = false;
    }
    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    



}
