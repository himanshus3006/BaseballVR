using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    //public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBall());
    }
    IEnumerator CreateBall()
    {
        yield return new WaitForSeconds(6f);
        Instantiate(this.gameObject, new Vector3(0 , 1, 7), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
