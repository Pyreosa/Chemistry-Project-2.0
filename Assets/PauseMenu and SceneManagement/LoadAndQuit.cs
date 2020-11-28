using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndQuit : MonoBehaviour
{
    public void LoadMenu()
    {
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
    }

    public void LoadTableTop()
    {       
              Time.timeScale = 1f;
              SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


