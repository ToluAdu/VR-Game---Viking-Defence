using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class spawner : MonoBehaviour
{


    Vector3 spawnlocation;

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private int enemyspawncount;
    public int enemykillcount;
    bool wave1done;
    bool wave2done;
    bool wave3done;
    bool lvlover;
    public bool levelclear;

    public AudioSource siren;

    public GameObject wave1screen;
    public GameObject wave2screen;
    public GameObject wave3screen;
    public GameObject lvlcomplete;
    public GameObject optionmenu;


    [SerializeField] Text countdownText;
    float currentTime = 0f;
    float startingTime = 15f;
    bool timerEnd = false;
    bool timerrun;
    // Use this for initialization
    void Start()
    {
        // Vector3 spawnlocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

        wave1screen.SetActive(false);
        wave2screen.SetActive(false);
        wave3screen.SetActive(false);
        lvlcomplete.SetActive(false);
        optionmenu.SetActive(false);

        currentTime = startingTime;

    }

    public void SpawnObject()
    {
        //GameObject localspawnee = spawnee;
       Instantiate(spawnee, transform.position, transform.rotation);
        enemyspawncount++;







        //Destroy(spawnee, 1.0f);
        /*if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }*/
        
    }


    // Update is called once per frame
    void Update()
    {
        if(timerrun== false)
        {

            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                Destroy(countdownText);
                timerrun = true;

            }


        }





        //Debug.Log("Enemy Kills ="+0);

        if (enemykillcount == 0 && wave1done==false && lvlover==false)
        {
            //Wave1
            StartCoroutine("Wave1");
            
        }

        if (enemykillcount== 10 && wave2done == false && lvlover == false)
        {
            //Wave2
            CancelInvoke("SpawnObject");
            StartCoroutine("Wave2");
            
        }

        if (enemykillcount == 15 && wave3done == false && lvlover == false)
        {
            //Wave3
            CancelInvoke("SpawnObject");
            StartCoroutine("Wave3");
            
        }

        if (enemykillcount == 20 )
        {
            CancelInvoke("SpawnObject");
            Debug.Log("LEVEL PASSED!");
            StartCoroutine("lvldone");

            
            
            //Level passed!
        }

    }

    IEnumerator Wave1()
    {
        
        wave1done = true;
        // wait for 1 second
        Debug.Log("Wave 1 in 10 seconds pickup weapon");
        wave1screen.SetActive(true);
        yield return new WaitForSeconds(15.0f);
        siren.Play();
        wave1screen.SetActive(false);
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);


    }

    IEnumerator Wave2()
    {
        wave2done = true;
        levelclear = true;
        enemykillcount = 0;
        // wait for 1 second
        Debug.Log("Wave 2 in 10 seconds");
        wave2screen.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        siren.Play();
        wave2screen.SetActive(false);
        levelclear = false;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);


    }

    IEnumerator Wave3()
    {
        wave3done = true;
        levelclear = true;
        enemykillcount = 0;
        // wait for 1 second
        Debug.Log("Wave 3 in 10 seconds");
        wave3screen.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        siren.Play();
        wave3screen.SetActive(false);
        levelclear = false;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
       

    }


    IEnumerator lvldone()
    {

        levelclear = true;
        // wait for 1 second
        Debug.Log("Next level in 10 seconds");
        lvlcomplete.SetActive(true);
        yield return new WaitForSeconds(10.0f);
       lvlcomplete.SetActive(false);


        PointerController PC = GameObject.Find("Enemy").GetComponent<PointerController>();
        PC.ActivePointer();
        optionmenu.SetActive(true);

      



        Time.timeScale = 0;


        // Next scene

    }



}
