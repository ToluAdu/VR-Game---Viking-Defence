using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnMovScript : MonoBehaviour
{
   

    private Transform targetfocus;


    // Start is called before the first frame update
    void Start()
    {
        targetfocus = GameObject.FindGameObjectWithTag("city").transform;
        //StartCoroutine("DestroySphere");
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = targetfocus.position - this.transform.position;
        //Debug.Log(target.magnitude);

        transform.LookAt(targetfocus.transform);
        float speed = Random.Range(1f, 10f);
        transform.Translate(0, 0, speed * Time.deltaTime);
        // Destroy(gameObject, 8.0f);

    }

    void showcoords()
    {

        Vector3 coords = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log("enemy coords: " + coords);


    }

    IEnumerator DestroySphere()
    {
        //StartCoroutine("CancelTriggerZone");
        yield return new WaitForSeconds(10);

        Destroy(gameObject,5.0f);
    }

}