using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
        MENU,
        PREGAME, // rounds number sel
        GAME,
        POSTGAME
    };

    [Header("Game State")]
    public StateType state;
    public int roundsTotal;
    public int roundsPlayed;

    [Header("Round timer")]
    [Range(0.0f, 300.0f)]
    public float roundTime = 30.0f;
    public countdownTimer timer;
    public String timerBoxMessage;
    public bool enableTimerBox;
    public bool timerOver; // timer flag

    [Header("Any Text Box")]
    public DisplayAnyMessage displayMsg;
    public String anyTextBoxMessage;
    public bool enableAnyTextBox;

    private Button playButton;

    public static GameManagementScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Memo : "Makes the object target not be destroyed automatically when loading a new scene."
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        resetAll();
        this.state = StateType.MENU;
    }

    void Update() // while
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
                    }
                    else
                    {
                        Debug.Log("starting new round, round " + roundsPlayed);
                        GoToGameStart();
                    }
                }
                break;
        }

    }


    public void GoToMenu()
    {
     // Debug.Log("Going to MAIN MENU ");
        resetAll();
        state = StateType.MENU;
        SceneManager.LoadScene(0); // scene 0 : main menu
    }

    public void GoToPreGameSettings()
    {
        state = StateType.PREGAME;
        playButton.enabled = false;
    }

    public void GoToGameStart()
    {
    //  Debug.Log("Go to GAME SCENE. Rounds played : " + roundsPlayed);
        state = StateType.GAME;
        SceneManager.LoadScene(1); // scene 1 : game scene
        enableTimerBox = true; // show timer
        enableAnyTextBox = true; // show ready set go box
        StartCoroutine(showReadySetGo());
    }
    
    public void GoToWinnerChicken()
    {
        state = StateType.POSTGAME;
        resetAll();
        
        Debug.Log("round over");
    }
    
    public IEnumerator showReadySetGo()
    {
        yield return displayMsg.ReadySetGo();
        this.timer.StartTimer();        
    }

    void resetAll() 
    {
        Debug.Log("resetting all");
        enableTimerBox = false;
        enableAnyTextBox = false;
        timerBoxMessage = "";
        anyTextBoxMessage= "";
        roundsTotal = 3;
        roundsPlayed = 0;

        //reset all attributes
    }

   

}
