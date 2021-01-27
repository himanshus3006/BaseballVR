using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    void Start()
    {
        GetComponent<GameObject>();
      //  GetComponent<ParabollaController>();
        StartCoroutine(Pitch());
    }


    // Update is called once per frame
    IEnumerator Pitch()
    {
        yield return new WaitForSeconds(6f);
        Instantiate(this.gameObject, transform.position, Quaternion.identity);
        GetComponent<ParabollaController>().FollowParabola();
        StartCoroutine(DestroyParabolla());

        IEnumerator DestroyParabolla()
        {
            yield return new WaitForSeconds(7f);
            

        }
    }
    void Update()
    {
      
    }
}
