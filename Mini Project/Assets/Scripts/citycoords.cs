using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citycoords : MonoBehaviour
{
    private Transform targetfocus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void showcoords()
    {

        Vector3 coords = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("city coords: " + coords);
    }


}