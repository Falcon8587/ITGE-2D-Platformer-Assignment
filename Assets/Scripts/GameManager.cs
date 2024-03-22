using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lvlendUI;
    public GameObject mainmenuui;
    public GameObject GameQuit;
    
    void Update()
    {
        if (Input.GetKeyDown("r")) 
        {
            Reset();        
        }
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        lvlendUI.SetActive(false);
    }

    public void mainmenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void LS1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void LS2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }

    public void quitgame()
    {
        Application.Quit();
    }

    public void End()
    {
        Time.timeScale = 0f;
        lvlendUI.SetActive(true);
    }

    public void QuitGameUI()
    {
        GameQuit.SetActive(true);
        mainmenuui.SetActive(false);
    }

    public void QuitGamegoback()
    {
        mainmenuui.SetActive(true);
        GameQuit.SetActive(false);
    }
}
