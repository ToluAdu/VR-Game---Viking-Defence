using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public GameObject pointer;
    public GameObject sphere;
    void Start()
    {
       pointer.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivePointer()
    {
        sphere.SetActive(true);
        pointer.SetActive(true);
        
    }
}
