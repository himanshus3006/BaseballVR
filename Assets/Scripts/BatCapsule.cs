using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsule : MonoBehaviour
{
    //Config
    [SerializeField] private BatCapsuleFollower batCapsuleFollower;


    // Spawn the bat capsule and set it to follow the bat
    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(batCapsuleFollower);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnBatCapsuleFollower();
    }
}