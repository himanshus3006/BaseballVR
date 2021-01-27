using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Baseball")
        {
            FindObjectOfType<GameManager>().ProcessScore(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
