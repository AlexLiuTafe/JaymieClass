﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class PauseMenu : MonoBehaviour
{
     
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPause)
            {
                Resume();
                
            }
            else
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;


    }
    public void Pause()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        
    }
}
