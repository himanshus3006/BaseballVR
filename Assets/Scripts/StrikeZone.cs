using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeZone : MonoBehaviour
{
    [SerializeField] AudioClip strike = null;
    public int strikeCount = 0;
    int pitcherScore;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Baseball"))
        {
            
                Debug.Log("Strike");
                GetComponent<AudioSource>().clip = strike; // get death audio clip
                GetComponent<AudioSource>().Play(); // play death audio clip
                Destroy(collision.gameObject, 0.01f);
           strikeCount++;
            pitcherScore += 10;

        }
    
    } 
   

// Update is called once per frame
void Update()
    {
       FindObjectOfType<GameManager>().ProcessStrikeCount(strikeCount,pitcherScore);
    }
}

