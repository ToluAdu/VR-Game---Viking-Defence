using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowEnemySpawner : MonoBehaviour
{
   

    public GameObject spawnee;
    public GameObject Boss;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    private int noOfEnemy = 0;
    private bool firstWaveEnd = false;
    private bool secWaveEnd = false;

    private GameObject BossWarning;
    public GameObject PickWeaponP;
    public GameObject FirstWaveP;
    public GameObject SecWaveP;
    private Boolean BossSpawn = false;
    public GameObject Shield;


    [SerializeField] Text countdownText;
    float currentTime = 0f;
    float startingTime = 15f;
    bool timerEnd = false;
    void Start()
    {
        currentTime = startingTime;
        BossWarning = GameObject.Find("BossPanel");
        BossWarning.SetActive(false);
        Boss.SetActive(false);
        SecWaveP.SetActive(false);
        FirstWaveP.SetActive(false);
        PickWeaponP.SetActive(true);
        stopSpawning = true;
        Shield.GetComponent<Collider>().enabled = !Shield.GetComponent<Collider>().enabled;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0 && !timerEnd)
        {
            currentTime = 0;
            //Destroy(countdownText);
            countdownText.enabled = false;
            PickWeaponP.SetActive(false);
            FirstWaveP.SetActive(true);
            StartCoroutine("FirstWaveTime");
            SpawningEnemy();
            stopSpawning = false;
            Shield.GetComponent<Collider>().enabled = true;
            timerEnd = true;
        }

        //Debug.Log("No of Enemy: " + noOfEnemy);

        if (noOfEnemy >= 10 && !firstWaveEnd)
        {
            stopSpawning = true;
            StartCoroutine(SecondWave());
            firstWaveEnd = true;
        }
        if (noOfEnemy >= 25 && !secWaveEnd)
        {
            stopSpawning = true;
            StartCoroutine(BossCoroutine());
            secWaveEnd = true;
        }
    }



    public void SpawnObject()
    {
        Vector3 position = new Vector3(UnityEngine.Random.Range(-48, 40), 4.6f, 35);
        Instantiate(spawnee, position, Quaternion.identity);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        noOfEnemy++;
    }
    public void SpawnObject2()
    {

        //Instantiate(spawnee, transform.position, transform.rotation);
        Vector3 position2 = new Vector3(UnityEngine.Random.Range(-48, 40), 4.6f, 35);
        Instantiate(spawnee, position2, Quaternion.identity);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject2");
        }
        noOfEnemy++;
    }

    void SpawningEnemy()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        InvokeRepeating("SpawnObject2", spawnTime, spawnDelay + 2);
    }

    // Update is called once per frame
   

    private void BigBoss()
    {
        
        StartCoroutine(WarningCoroutine());
        //Debug.Log("Big boss comes");
        Boss.SetActive(true);
    }

    IEnumerator WarningCoroutine()
    {
        BossWarning.SetActive(true);
        yield return new WaitForSeconds(10);
        BossWarning.SetActive(false);
    }

    IEnumerator BossCoroutine()
    {
       
        yield return new WaitForSeconds(30);
        BigBoss();
    }

    IEnumerator SecondWave()
    {
        yield return new WaitForSeconds(30);
        StartCoroutine(SecondWaveP());
        stopSpawning = false;
        SpawningEnemy();
    }
    IEnumerator SecondWaveP()
    {
        SecWaveP.SetActive(true);
        yield return new WaitForSeconds(10);
        SecWaveP.SetActive(false);
    }
    IEnumerator FirstWaveTime()
    {
        
        yield return new WaitForSeconds(5);
        FirstWaveP.SetActive(false);
    }
}
