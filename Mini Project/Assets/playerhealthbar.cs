using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerhealthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public AudioSource gotHit;
    public GameObject gameover;
    public Slider playerHealth;
    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        gotHit.Stop();
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.value = health;
        Debug.Log("Player Health: "+ health);

        if(health<=0)
        {
            
            // Gameover Screen
            gameover.SetActive(true);
            PointerController PC = GameObject.Find("Enemy").GetComponent<PointerController>();
            PC.ActivePointer();
            Time.timeScale = 0;
        }
    }


    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "Dagger")
        
        {
            if(health > 0)
            {
                health = health - 3;
                gotHit.Play();
            }
            
        }


        /*if (other.gameObject.tag == "gun")
        {
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);

        }*/


    }



   







}
