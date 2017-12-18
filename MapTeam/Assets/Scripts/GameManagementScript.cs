using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
        MENU,
        GAME
    };

    public StateType state;
    public CountdownTimer timer;
    public Text timerBox;


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
        this.state = StateType.MENU;
        timerBox.text = "";
        timerBox.enabled = false;
    }

    void Update() // while
    {
        if (timerBox.enabled)
        {
            timerBox.text = timer.timerText;
        }

        switch (state)
        {
            case StateType.MENU :
                break;

            case StateType.GAME :

                if (timer.activated == false)
                { //une fois round fini
                    GoToMenu(); // ENLEVER
                }
                break;
        }

    }


    public void GoToMenu()
    {
        Debug.Log("Going to MAIN MENU ");
        resetAll();
        state = StateType.MENU;
        SceneManager.LoadScene(0); // scene 0 : main menu
    }

    public void GoToGame()
    {
        Debug.Log("Go to GAME SCENE ");
        timerBox.enabled = true; // show timer
        state = StateType.GAME;
        SceneManager.LoadScene(1); // scene 1 : game scene
        this.timer.StartTimer();        
    }
    

    void resetAll() 
    {
        timerBox.enabled = false;
        timerBox.text = "";
        //TODO
        //reset all attributes
    }

}
