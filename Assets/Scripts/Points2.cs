using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // acts as invisible detector to check if ball crossed that area or not and processes score accordingly
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Baseball")
        {
            FindObjectOfType<GameManager>().ProcessScore(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
