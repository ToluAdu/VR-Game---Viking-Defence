using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapfall : MonoBehaviour
{
    public GameObject gameover;
    public AudioSource fall;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) // C#, type first, name in second
    {
        if (other.gameObject.tag == "Player")
        // By using {}, the condition apply to that entire scope, instead of the next line.
        {
            //Gameover Death
            fall.Play();

            StartCoroutine("WaitThreeSec");
        }

       
    }


    IEnumerator WaitThreeSec()
    {
        yield return new WaitForSeconds(2);
        gameover.SetActive(true);
        PointerController PC = GameObject.Find("Enemy").GetComponent<PointerController>();
        PC.ActivePointer();
        Time.timeScale = 0;

    }





}
