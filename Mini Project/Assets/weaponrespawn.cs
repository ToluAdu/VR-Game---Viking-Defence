using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponrespawn : MonoBehaviour
{
    Vector3 originalpos;
    Quaternion originalRota;
    
    // Start is called before the first frame update
    void Start()
    {
        
        originalpos = gameObject.transform.position;
        originalRota = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("controller"))
        {
            gameObject.transform.position = originalpos;
            gameObject.transform.rotation = originalRota;
        }

        
    }

}
