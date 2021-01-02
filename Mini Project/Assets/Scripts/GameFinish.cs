using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameFinish : MonoBehaviour
{
    public GameObject playerDiePanel;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject laserPointer;

    private void Awake()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        playerDiePanel.SetActive(false);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        laserPointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDie()
    {
        playerDiePanel.SetActive(true);
        TimeStop();
    }
    public void Win()
    {
        WinPanel.SetActive(true);
        TimeStop();
    }
    public void Lose()
    {
        LosePanel.SetActive(true);
        TimeStop();
    }



    void TimeStop()
    {
        laserPointer.SetActive(true);
        Time.timeScale = 0;
    }
}
