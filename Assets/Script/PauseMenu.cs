﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlls;

    public GameObject ctlr;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ctlr.SetActive(false);
    }

    public void MenuControll()
    {
        pauseMenuUI.SetActive(false);
        controlls.SetActive(true);
    }

    public void EnableControl() {
        ctlr.SetActive(true);
    }
    public void DisableControl()
    {
        ctlr.SetActive(false);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
