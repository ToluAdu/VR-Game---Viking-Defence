using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castlehealthbar : MonoBehaviour
{
    public GameObject gameover;
    // Start is called before the first frame update
    public int health = 100;

    void Start()
    {
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Castle Health: " + health);

        if(health<=0)
        {
            gameover.SetActive(true);
            PointerController PC = GameObject.Find("Enemy").GetComponent<PointerController>();
            PC.ActivePointer();
            Time.timeScale = 0;
        }
       
    }


    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "enemy")

        {
            if(health>0)
            {
                health = health - 10;
            }
           
        }


    }
}
