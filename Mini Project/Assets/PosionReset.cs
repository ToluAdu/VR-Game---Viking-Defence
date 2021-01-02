using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionReset : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRota;
    void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRota = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Environment")
        {
            gameObject.transform.position = originalPos;
            gameObject.transform.rotation = originalRota;
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Shield")
    //    {
    //        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
    //    }
    //}
}
