using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour 
    {
     private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
     public bool gripButtonDown = false;
     public bool gripButtonUp = false;
     public bool gripButtonPressed = false;


     private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
     public bool triggerButtonDown = false;
     public bool triggerButtonUp = false;
     public bool triggerButtonPressed = false;

        private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
        private SteamVR_TrackedObject trackedObj;
 
    private GameObject pickup;
 	void Start()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
            return;
         }
    void Update()
    {
        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if (gripButtonDown)
        {
            Debug.Log("Grip Button was just pressed");
            if (controller.GetPressDown(gripButton) && pickup != null)
            {
                pickup.transform.parent = this.transform;
                pickup.GetComponent<Rigidbody>().useGravity = false;
            }
            if (gripButtonUp)
            {
                Debug.Log("Grip Button was just unpressed");
            }
            if (triggerButtonDown)
            {
                Debug.Log("Trigger Button was just pressed");
            }
            if (triggerButtonUp)
            {
                Debug.Log("Trigger Button was just unpressed");
                if (controller.GetPressUp(gripButton) && pickup != null)
                {
                    pickup.transform.parent = null;
                    pickup.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
{
    pickup = collider.gameObject;
        }

    private void OnTriggerExit(Collider collider)
{
    pickup = null;
        }
 }