using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscript : MonoBehaviour
{


    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "enemychar")        
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<EnemyController>().isInTriggerZone = true;
            
        }

        


    }


}