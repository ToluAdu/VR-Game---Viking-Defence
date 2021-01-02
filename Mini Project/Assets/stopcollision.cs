using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopcollision : MonoBehaviour
{
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    void  OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Player" || other.collider.tag == "controller")
        {
            col.enabled = !col.enabled;
        }
    }

}
