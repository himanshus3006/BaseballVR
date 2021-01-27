using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallZone : MonoBehaviour
{
    int pitchCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Baseball"))
        {

            Debug.Log("ball");

            pitchCount++;
        }

    }
  /*  private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Baseball"))
        {

            Debug.Log("ball");
         
            pitchCount++;
        }

    } */


    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameManagerPitcher>().ProcessPitchCount(pitchCount);
    }
}
