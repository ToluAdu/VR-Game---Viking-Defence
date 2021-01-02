using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newspawner : MonoBehaviour
{
    bool keepSpawning = true;
    public GameObject spawnee;
  
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnAtIntervals(2f)); // Or whatever delay we want.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {
        // Repeat until keepSpawning == false or this GameObject is disabled/destroyed.
        while (keepSpawning)
        {
            // Put this coroutine to sleep until the next spawn time.
            yield return new WaitForSeconds(secondsBetweenSpawns);

            // Now it's time to spawn again.
            Spawn();
        }
    }


    void Spawn()
    {

        Instantiate(spawnee, transform.position, transform.rotation);

    }


}
