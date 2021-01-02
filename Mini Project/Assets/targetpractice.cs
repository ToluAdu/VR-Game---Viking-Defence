using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetpractice : MonoBehaviour
{

    public float health = 10f;
    public bool enemydown = false;
    public AudioSource deathsound;
    public GameObject player;





    private void Start()
    {
        player = GameObject.Find("PaladinSpawn");
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;


        if (health <= 0f)
        {

            Die();

        }



    }

    private void Update()
    {
        if(player.GetComponent<spawner>().levelclear==true)
        {
            Destroy(gameObject, 1.5f);
        }
    }


    void Die()
    {
        enemydown = true;

        Destroy(gameObject,3.0f);
        //enemydown = false;
        deathsound.Play();
        player.GetComponent<spawner>().enemykillcount++;

    }






}
