using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagementScript : MonoBehaviour {

    public enum StateType
    {
        MENU,
        GAME
    };

    public StateType state;

    [Header("Round Settings")]
    public float roundTime = 30.0f;

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

    void Update()
    {
        switch (state)
        {
            case StateType.MENU:
                resetAll();
                break;

            case StateType.GAME:
                break;
        }

    }

    void resetAll() 
    {
        //TODO
        //reset all attributes
    }

    public void GoToMenu()
    {
        Debug.Log("Going to MAIN MENU ");
        SceneManager.LoadScene(0); // scene 0 : main menu
    }

    public void GoToGame()
    {
        Debug.Log("Go to GAME SCENE ");
        SceneManager.LoadScene(1); // scene 1 : game scene
    }

}
