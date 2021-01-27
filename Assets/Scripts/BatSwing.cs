using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSwing : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
   // public bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator.SetBool("isColliding", false);
    }


  // acts as invisible detector to check if ball crossed that area or not and plays bat animation accordingly
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Baseball")
        {
            myAnimator.SetBool("isColliding", true);
            StartCoroutine(Animate());
        }
        else
            myAnimator.SetBool("isColliding", false);
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(3f);
        myAnimator.SetBool("isColliding", false);
      

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
