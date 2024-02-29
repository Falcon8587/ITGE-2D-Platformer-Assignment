using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject lvlendUI;
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

    public void End()
    {
        lvlendUI.SetActive(true);
    }
}
