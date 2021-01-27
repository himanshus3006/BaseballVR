using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
   //Config 
    float magnitude;

    void Start()
    {
 
    }
    // checks  for collision and determines the direction and force the ball should travel in after hitting the bat
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baseball") 
        {
            
            Vector3 direction = (transform.position - collision.contacts[0].point).normalized;
            magnitude = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 50f);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction *magnitude,ForceMode.Impulse );
            Destroy(collision.gameObject, 6f);
        }

       
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
