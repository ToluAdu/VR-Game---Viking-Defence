using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnter : MonoBehaviour
{
    private int enemyNo = 0;
    public AudioSource enterSound;
    public AudioSource bossSound;
    public GameObject OneHeart, SecHeart, ThirdHeart, FourthHeart, FifthHeart;
    private void Awake()
    {
        enemyNo = 0;        
        Time.timeScale = 1;
        
    }
    void Start()
    {
        enterSound.Stop();
        bossSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyNo == 1)
        {
            OneHeart.SetActive(false);
        }else if (enemyNo == 2)
        {
            SecHeart.SetActive(false);
        }else if(enemyNo == 3)
        {
            ThirdHeart.SetActive(false);
        }else if(enemyNo == 4)
        {
            FourthHeart.SetActive(false);
        }else if(enemyNo == 5)
        {
            FifthHeart.SetActive(false);
            Gamelose();            
        }
    }

    void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "enemy")
        {
            enterSound.Play();
            Destroy(other.gameObject,2.0f);
            enemyNo++;
        }

        if (other.gameObject.tag == "Boss")
        {
            bossSound.Play();
            Destroy(other.gameObject, 2.0f);
            Gamelose();
        }
    }

    void Gamelose()
    {
        GameFinish GF = GameObject.Find("GameFinish").GetComponent<GameFinish>();
        GF.Lose();
    }
}
