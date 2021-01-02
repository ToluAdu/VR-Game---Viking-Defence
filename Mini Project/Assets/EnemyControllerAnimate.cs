using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerAnimate : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject enemyattractor;
    public Transform enemyattractorpos;
    public Camera cam;
    public Animator anim;    
    public bool isInTriggerZone;
    public bool reachedtarget;

    void Start()
    {
        

        reachedtarget = false;

        enemyattractorpos = GameObject.Find("EnemyAttractor").transform;
        anim = GetComponent<Animator>();  // ONLY HAVE ONE ANIMATOR!
        anim.SetInteger("State", 0); // idle 0
    }

    // Update is called once per frame
    void Update()
    {

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        //attack dogs mechanic
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            
            anim.SetInteger("State", 1); // running 1

            if (Physics.Raycast(ray, out hit))
            {

                agent.SetDestination(hit.point);

            }


        }

      else if (agent.remainingDistance == agent.stoppingDistance)
        {

          
            
                
            anim.SetInteger("State",0); // idle 0
            
  
            
        }*/

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$




         agent.SetDestination(enemyattractorpos.position);

       

        if (reachedtarget != true)
        {
            anim.SetInteger("State", 1);
        }
           

       
        //DISCONTINUEDagent.SetDestination(enemyattractor.transform.position);

    }




    void OnTriggerEnter(Collider theCollision)
    {

        if (theCollision.tag == "city")
        {

            reachedtarget = true;
            anim.SetInteger("State", 0);
        }



    }






    IEnumerator CancelTriggerZone()
    {
        //StartCoroutine("CancelTriggerZone");
        yield return new WaitForSeconds(2);
        isInTriggerZone = false;
        Debug.Log("isTriggerZone: " + isInTriggerZone);
    }
}
