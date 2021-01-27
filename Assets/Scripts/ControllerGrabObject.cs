using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControllerGrabObject : MonoBehaviour
{
    //Config
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean xButton;
    public SteamVR_Action_Boolean yButton;
    bool ball = false;

    float randomVelocity;
    float randomAngularVelocity;
    //public SteamVR_Action_Boolean aButton;
   // public SteamVR_Action_Boolean bButton;
    

    private GameObject collidingObject; 
    private GameObject objectInHand; 



    // Start is called before the first frame update
    void Start()
    {

    }

    private void SetCollidingObject(Collider col)
    {
      
        if (collidingObject || !col.GetComponent<Rigidbody>()) // to check if player is holding something or if object which is being picked up has rigidbody
        {
            return;
        }
        
        collidingObject = col.gameObject; 
    }

    // allows for grabing
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other); // allows for grabing
    }

    // ensuring grab 
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // reseting grab availability
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        
        objectInHand = collidingObject;  
        collidingObject = null;
        
        var joint = AddFixedJoint(); // adds joint to hold the object in place
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    
    // strong joint so that it doesnt break easily
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // remove fixed joint
        if (GetComponent<FixedJoint>())
        {

            
            GetComponent<FixedJoint>().connectedBody = null;

            Destroy(GetComponent<FixedJoint>());

            
            // check for fastball or curve ball and assign velocity based on choice
          
            if (ball )
            {
                
                objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity() * randomVelocity;
                objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity() *0.5f;
                Debug.Log("xbutton");
                Destroy(objectInHand, 5f);
            }
            else if (!ball)
            {
                objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity() * 1.5f;
                objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity() * randomAngularVelocity;
                Debug.Log("ybutton");
               Destroy(objectInHand, 5f);
            }
            else
            {
                objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity() * 0f;
                objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity() * 0f;
                Debug.Log("default");
                Destroy(objectInHand, 5f);
            }
        }
        // reset vairable for next grab
        objectInHand = null;
    }






    // Update is called once per frame
    void Update()
    {
        // range calculate
        randomVelocity = Random.Range(2.0f, 3.5f);
        randomAngularVelocity = Random.Range(2f, 3.5f);

        //checks for button press
        if (xButton.GetStateDown(handType))
        {
            bool reff = (yButton.GetStateDown(handType));
            reff = false;
            ball = true;
        }
        if ((yButton.GetStateDown(handType)))
        {
            bool reff = (xButton.GetStateDown(handType));
            reff = false;
            ball = false;
        }
        
        // when button is held we can grab and the when it is released we can throw
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }
        
        if (grabAction.GetLastStateUp(handType))
        {
                ReleaseObject();
               
        }
    }
}
    

