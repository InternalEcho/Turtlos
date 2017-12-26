using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // Use this for initialization
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject postGameMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void displayPostGameMenu()
    {
        Time.timeScale = 0f;
        postGameMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        postGameMenu.SetActive(false);
        GameManagementScript.Instance.GoToGameStart();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        postGameMenu.SetActive(false);
        GameManagementScript.Instance.GoToMenu();
    }
}
