using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{

    public GameObject introPanel;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        introPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        SceneManager.LoadScene("MainGame01");

    }

    public void LevelButton()
    {
    }

    public void instructionButton()
    {
        introPanel.SetActive(true);
    }
    public void closePanel()
    {
        introPanel.SetActive(false) ;
    }

    public void ExitAPP()
    {
        Application.Quit();
    }
}
