using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void GoToMenu()
    {
        GameManagementScript.Instance.GoToMenu();
    }

    public void GoToGame()
    {
        GameManagementScript.Instance.GoToGameStart();
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
