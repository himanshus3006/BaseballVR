using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour
{
    //Config
    private BatCapsule batFollower;
    private Rigidbody myRigidbody;
    private Vector3 CapsuleVelocity;

    [SerializeField] private float sensitivityVelocity = 100f;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // to set direction and rotation of capsule on bat
        Vector3 destination = batFollower.transform.position; 
        myRigidbody.transform.rotation = transform.rotation;

        CapsuleVelocity = (destination - myRigidbody.transform.position) * sensitivityVelocity; //calculate velocity of capsule

        myRigidbody.velocity = CapsuleVelocity;
        transform.rotation = batFollower.transform.rotation; // to keep the  capsules locked in the set location
    }

    public void SetFollowTarget(BatCapsule batFollower)
    {
        this.batFollower = batFollower; 
    }
}