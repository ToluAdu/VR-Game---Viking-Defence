using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public AudioSource gunshot;
    public GameObject spawnee;

    public GameObject fpsCam;
    public GameObject cylinder;

    bool canshoot = false;
    //public ParticleSystem muzzleFlash;


    // Start is called before the first frame update
    void Start()
    {
        cylinder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.red);

        cylinder.transform.position = transform.position;


        if (Input.GetButtonDown("Fire1"))
        {
            if (canshoot == true)
            {

                Shoot();
            }
            

        }
        
    }
  public void Shoot()
    {
        

        


        RaycastHit hit;
        gunshot.Play();

       if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //fpsCam.
        {
            Debug.Log(hit.transform.name + "OBJECT HIT");

           targetpractice target = hit.transform.GetComponent<targetpractice>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }
            
        }

        Instantiate(spawnee, transform.position, transform.rotation);//@@@

}



    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "controller")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            canshoot = true;
            cylinder.SetActive(true);
            
        }

       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "controller")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            canshoot = true;
            cylinder.SetActive(true);

        }
    }


    void OnTriggerExit(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "controller")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            canshoot = false;
            cylinder.SetActive(false);
        }


    }




}
