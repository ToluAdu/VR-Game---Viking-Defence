using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    
    public AudioSource music;
    public AudioSource Sword;
    public AudioSource beingHit;
    public Slider playerHealth;
    

    
       
    public GameObject sphere;

    void Awake()
    {        
        Time.timeScale = 1;
    }
    void Start()
    {
        
        music.Play();
        Sword.Stop();
        beingHit.Stop();
    }

    
    void Update()
    {
        
        playerHealth.value = health;
        Debug.Log("Health: " + health);
        if(health == 0)
        {            
            sphere.SetActive(true);
            GameFinish GF = GameObject.Find("GameFinish").GetComponent<GameFinish>();
            GF.PlayerDie();

        }
    }

      void OnTriggerEnter(Collider other)
      {

        if (other.gameObject.tag == "Dagger")
        {
            health = health-10;
            
            beingHit.Play();
        }
    
        if(other.gameObject.tag == "Axe" || other.gameObject.tag == "Sword_Snow" )
        {
            Physics.IgnoreCollision(transform.GetComponent<Collider>(), other.GetComponent<Collider>(), true);
            //Sword.Play();
        }

        if(other.gameObject.tag == "Aid")
        {
            health = 100;
            Destroy(other.gameObject);
        }

      }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dagger")
        {
            //health = health-10;
           
           
        }

        if (collision.gameObject.tag == "Axe" || collision.gameObject.tag == "Sword_Scow" )
        {
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), true);
            
        }
    }

    public void ShieldHit()
    {
        health = health + 10;
    }
}
