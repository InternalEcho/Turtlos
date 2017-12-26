using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    // Use this for initialization
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject postGameMenu;
    public GameObject inGameUI;

    private string timerText;
    public float roundDuration = 5f;
    private float timeLeft;

    private Coroutine countdownCoroutine;

    private void Start()
    {
        countdownCoroutine = StartCoroutine(StartCountdown());
    }

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
        GameObject.Find("GameCanvas/In game UI/Text").GetComponent<Text>().text = timeLeft.ToString();
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
        postGameMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManagementScript.Instance.GoToGameStart();

        StopCoroutine(countdownCoroutine);
        StartCoroutine(StartCountdown());
    }

    public void MainMenu()
    {
        postGameMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManagementScript.Instance.GoToMenu();
    }

    public IEnumerator StartCountdown()
    {
        timeLeft = roundDuration;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
        displayPostGameMenu();
    }
}
