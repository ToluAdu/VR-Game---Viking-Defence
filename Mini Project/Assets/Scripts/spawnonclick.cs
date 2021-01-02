using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnonclick : MonoBehaviour
{


    Vector3 spawnlocation;

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
             

    // Use this for initialization
    void Start()
    {
       // Vector3 spawnlocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }

    public void SpawnObject()
    {
        
      




    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(spawnee, transform.position, transform.rotation);

        }
    }

}
