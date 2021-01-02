using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
 
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("VRMENU");
    }

    public void NextLvl()
    {
        SceneManager.LoadScene("SnowScene");
    }
}
