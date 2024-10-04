using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class ManualXRControl : MonoBehaviour
{
    // Coroutine to start XR
    public IEnumerator StartXRCoroutine()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }

    // Method to stop XR
    public void StopXR()
    {
        Debug.Log("Stopping XR...");

        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }

    // Method to switch to VR
    public void SwitchToVR()
    {
        StartCoroutine(StartXRCoroutine());
    }

    // Method to switch back to non-VR mode
    public void SwitchToNonVR()
    {
        StopXR();
    }

    // Example usage for testing (You can remove this method if you handle the switching in your UI or game logic)
    void Update()
    {
        //// Press V key to switch to VR
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    Debug.Log("Switching to VR Mode...");
        //    SwitchToVR();
        //}

        //// Press N key to switch to Non-VR
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    Debug.Log("Switching to Non-VR Mode...");
        //    SwitchToNonVR();
        //}
    }
}
