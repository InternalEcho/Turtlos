using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject postGameMenu;
    //public GameObject inGameUI;
    public Text winnerText;
    public countdownTimer cdTimer;

    private void Start()
    {
        cdTimer = GameManagementScript.Instance.timer;
    }

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
        //Time.timeScale = 0f;
        GameManagementScript.Instance.timerOver = false;
        winnerText.text = "TIE GAME!";
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
        GameManagementScript.Instance.GoToGameStart();
    }

    public void MainMenu()
    {
        GameManagementScript.Instance.GoToMenu();
    }

    void OnDestroy()
    {
        postGameMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        cdTimer.StopTimer();
    }
}
