using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeZonePitcher : MonoBehaviour
{
    [SerializeField] AudioClip strike = null;
    public int strikeCount = 0;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Baseball"))
        {

            Debug.Log("Strike");
            GetComponent<AudioSource>().clip = strike; // get death audio clip
            GetComponent<AudioSource>().Play(); // play death audio clip
            strikeCount++;
        }
    }
  /* private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Baseball"))
        {

            Debug.Log("Strike");
            GetComponent<AudioSource>().clip = strike; // get death audio clip
            GetComponent<AudioSource>().Play(); // play death audio clip
            strikeCount++;
        }

    } */


    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<GameManagerPitcher>().ProcessStrikeCount(strikeCount);
    }
}
