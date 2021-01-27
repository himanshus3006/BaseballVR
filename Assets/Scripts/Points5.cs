using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Baseball")
        {
            FindObjectOfType<GameManager>().ProcessScore(4);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
