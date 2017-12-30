using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
        MENU,
        GAME,
        POSTGAME
    };

    [Header("Game State")]
    public StateType state;
    public int roundsTotal;
    public int roundsPlayed;
    public bool allowPlayerMovement;
    public AudioSource introMusic;

    [Header("Round timer")]
    [Range(0.0f, 300.0f)]
    public int roundTime = 30; 
    public countdownTimer timer;
    public String timerBoxMessage;
    public bool enableTimerBox;
    public bool timerOver; // timer flag

    [Header("Any Text Box")]
    public DisplayAnyMessage displayMsg;
    public String anyTextBoxMessage;
    public bool enableAnyTextBox;
    
    public static GameManagementScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        this.state = StateType.MENU;
        GoToMenu();
    }

    void Update()
    {

        switch (state)
        {
            case StateType.MENU :
                break;
                
            case StateType.GAME :

                timerBoxMessage = timer.timerText;
                anyTextBoxMessage = displayMsg.message;

                if (timerOver)
                {
                    timerOver = false;
                    roundsPlayed++;
                
                    if (roundsPlayed == roundsTotal)
                    {
                        Debug.Log("All rounds played.");
                        GoToWinnerChicken();
                    }
                    else
                    {
                        Debug.Log("starting new round, round " + roundsPlayed);
                        GoToGameStart();
                    }
                }
                break;

            default :
                break;
        }

    }


    public void GoToMenu()
    {
     // Debug.Log("Going to MAIN MENU ");
        resetAll();
        introMusic.Play();
        state = StateType.MENU;
        SceneManager.LoadScene(0); 
    }

    public void GoToGameStart()
    {
        //  Debug.Log("Go to GAME SCENE. Rounds played : " + roundsPlayed);
        introMusic.Stop();
        state = StateType.GAME;
        allowPlayerMovement = false; 
        enableTimerBox = true; 
        enableAnyTextBox = true;
        StopAllCoroutines(); 
        StartCoroutine(showReadySetGo());
        SceneManager.LoadScene(1);
    }
    
    public void GoToWinnerChicken()
    {
        state = StateType.POSTGAME;
        resetAll();
        GameObject.Find("GameCanvas").GetComponent<PauseMenu>().displayPostGameMenu();
    }
    
    public IEnumerator showReadySetGo()
    {
        yield return displayMsg.ReadySetGo();
        allowPlayerMovement = true;
        this.timer.StartTimer();        
    }

    //reset all attributes
    void resetAll() 
    {
        Debug.Log("Full reset");
        enableTimerBox = false;
        enableAnyTextBox = false;
        allowPlayerMovement = false;
        timerBoxMessage = "";
        anyTextBoxMessage= "";
        roundsTotal = 1;
        roundsPlayed = 0;
        StopAllCoroutines();
    }
    
}
